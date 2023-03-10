using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ColorGenerator
{
    private S_ColorSettings colorSettings;
    private Texture2D texture;

    private const int textureRes = 50;

    public void UpdateSettings(S_ColorSettings colorSettings)
    {
        this.colorSettings = colorSettings;

        if (texture == null)
        {
            texture = new Texture2D(textureRes, 1);
        }
    }

    public void UpdateElevation(S_MinMax elevationMinMax)
    {
        colorSettings.planetMaterial.SetVector("_elevationMinMax",
            new Vector4(elevationMinMax.Min, elevationMinMax.Max, 0.0f, 0.0f));
    }

    public void UpdateColors()
    {
        Color[] colors = new Color[textureRes];

        for(int i = 0; i < textureRes; i++)
        {
            colors[i] = colorSettings.gradient.Evaluate(i / (textureRes - 1.0f));
        }

        texture.SetPixels(colors);
        texture.Apply();

        colorSettings.planetMaterial.SetTexture("_texture", texture);
    }
}
