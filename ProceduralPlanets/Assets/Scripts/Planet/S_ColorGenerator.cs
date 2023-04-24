using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ColorGenerator
{
    private S_ColorSettings colorSettings;
    private Texture2D texture;

    private const int textureRes = 50;

    S_INoiseFilter biomeNoiseFilter;

    public void UpdateSettings(S_ColorSettings colorSettings)
    {
        this.colorSettings = colorSettings;

        if (texture == null || texture.height != colorSettings.biomeColorSettings.biomes.Length)
        {
            texture = new Texture2D(textureRes, colorSettings.biomeColorSettings.biomes.Length, TextureFormat.RGBA32, false);
        }

        biomeNoiseFilter = S_NoiseFilterFactory.CreateNosieFilter(colorSettings.biomeColorSettings.noise);
    }

    public void UpdateElevation(S_MinMax elevationMinMax)
    {
        colorSettings.planetMaterial.SetVector("_elevationMinMax",
            new Vector4(elevationMinMax.Min, elevationMinMax.Max, 0.0f, 0.0f));
    }

    public float BiomePercentFromPoint(Vector3 pointOnUnitSphere)
    {
        float heightPercent = (pointOnUnitSphere.y + 1) / 2.0f;
        heightPercent += biomeNoiseFilter.Evaluate(pointOnUnitSphere)
                        - (colorSettings.biomeColorSettings.noiseOffset) * colorSettings.biomeColorSettings.noiseStrength;

        float biomeIndex = 0;
        int numBiomes = colorSettings.biomeColorSettings.biomes.Length;
        float blendRange = colorSettings.biomeColorSettings.blendAmount * 0.5f + 0.001f;

        for(int i = 0; i < numBiomes; i++)
        {
            float dist = heightPercent - colorSettings.biomeColorSettings.biomes[i].startHeight;
            float weight = Mathf.InverseLerp(-blendRange, blendRange, dist);

            biomeIndex *= (1 - weight);
            biomeIndex += i * weight;
        }

        return biomeIndex / Mathf.Max(1, numBiomes - 1);
    }

    public void UpdateColors()
    {
        Color[] colors = new Color[texture.width * texture.height];

        int colorIndex = 0;
        foreach (var biome in colorSettings.biomeColorSettings.biomes)
        {
            for (int i = 0; i < textureRes; i++)
            {
                Color gradientColor = biome.gradient.Evaluate(i / (textureRes - 1.0f));
                Color tintColor = biome.tint;
                colors[colorIndex] = gradientColor * (1.0f - biome.tintPercent)
                                    + tintColor * biome.tintPercent;
                colorIndex++;
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        colorSettings.planetMaterial.SetTexture("_texture", texture);
    }
}
