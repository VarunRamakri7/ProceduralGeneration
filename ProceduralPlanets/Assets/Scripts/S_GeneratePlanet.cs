using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static S_ShapeSettings;

public class S_GeneratePlanet : MonoBehaviour
{
    [SerializeField]
    private S_Planet god;
    [SerializeField]
    private List<Gradient> gradients;

    private S_ShapeSettings shapeSettings;
    private S_ColorSettings colorSettings;
    private S_Planet planet;
    private Material planetMaterial;

    public void Start()
    {
        // Copy god's settings
        shapeSettings = new S_ShapeSettings(god.shapeSettings);
        colorSettings = new S_ColorSettings(god.colorSettings);

        planetMaterial = colorSettings.planetMaterial; // Set default planet material
        
        planet = this.gameObject.GetComponent<S_Planet>();
        //planet.enabled = false;
    }

    /// <summary>
    /// Generate planet with shape and color settings
    /// </summary>
    public void GeneratePlanet()
    {
        // Generate settings
        GenerateShapeSettings();
        GenerateColorSettings();

        // Reset planet properties
        planet.resolution = 64;
        planet.shapeSettings = shapeSettings;
        planet.colorSettings = colorSettings;
        planet.GeneratePlanet();
    }

    /// <summary>
    /// Generate planet for the given script
    /// </summary>
    /// <param name="planetScript">Script to generate plant for</param>
    public void GeneratePlanet(S_Planet planetScript)
    {
        // Create new settings instances
        shapeSettings = planetScript.shapeSettings;
        colorSettings = planetScript.colorSettings;

        // Generate settings
        GenerateShapeSettings();

        GenerateColorSettings();

        // Reset planet properties
        planetScript.resolution = 64;
        planetScript.shapeSettings = shapeSettings;
        planetScript.colorSettings = colorSettings;
        planetScript.GeneratePlanet();

        ResetSettings();
    }

    /// <summary>
    /// Randomly generate shape settings
    /// </summary>
    public void GenerateShapeSettings()
    {
        shapeSettings.planetRadius = Random.Range(1.0f, 5.0f);
        foreach(NoiseLayer noiseLayer in shapeSettings.noiseLayers)
        {
            noiseLayer.noiseSettings.filterType = S_NoiseSettings.FilterType.SIMPLE;
            noiseLayer.noiseSettings.simpleNoiseSettings.strength = Random.Range(-0.5f, 0.3f);
            noiseLayer.noiseSettings.simpleNoiseSettings.numLayers = 3;
            noiseLayer.noiseSettings.simpleNoiseSettings.baseRoughness = Random.Range(0.1f, 5.0f);
            noiseLayer.noiseSettings.simpleNoiseSettings.roughness = Random.Range(0.1f, 1.0f);
            noiseLayer.noiseSettings.simpleNoiseSettings.persistance = Random.Range(0.1f, 0.2f);
            noiseLayer.noiseSettings.simpleNoiseSettings.center = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            noiseLayer.noiseSettings.simpleNoiseSettings.minValue = Random.Range(0.5f, 0.8f);
        }
    }

    /// <summary>
    /// Randomly generate color settings
    /// </summary>
    public void GenerateColorSettings()
    {
        colorSettings.biomeColorSettings.noiseStrength = Random.Range(0.1f, 0.5f);
        colorSettings.biomeColorSettings.noiseOffset = Random.Range(2.0f, 5.0f);
        colorSettings.biomeColorSettings.blendAmount = Random.Range(0.25f, 1.0f);
        
        colorSettings.biomeColorSettings.noise.filterType = (S_NoiseSettings.FilterType)Random.Range(0, 1);
        switch(colorSettings.biomeColorSettings.noise.filterType)
        {
            case S_NoiseSettings.FilterType.SIMPLE:
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.strength = Random.Range(0.1f, 0.85f);
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.numLayers = 3;
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.baseRoughness = Random.Range(0.1f, 1.0f);
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.roughness = Random.Range(0.1f, 1.0f);
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.persistance = Random.Range(0.1f, 0.35f);
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.center = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                colorSettings.biomeColorSettings.noise.simpleNoiseSettings.minValue = 0.5f *
                    (colorSettings.biomeColorSettings.noise.simpleNoiseSettings.baseRoughness +
                    colorSettings.biomeColorSettings.noise.simpleNoiseSettings.roughness);
                break;
            case S_NoiseSettings.FilterType.RIGID:
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.strength = Random.Range(0.1f, 0.85f);
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.numLayers = 3;
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.baseRoughness = Random.Range(0.1f, 1.0f);
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.roughness = Random.Range(0.1f, 1.0f);
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.persistance = Random.Range(0.1f, 0.35f);
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.center = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.minValue = 0.5f *
                    (colorSettings.biomeColorSettings.noise.rigidNoiseSettings.baseRoughness +
                    colorSettings.biomeColorSettings.noise.rigidNoiseSettings.roughness);
                colorSettings.biomeColorSettings.noise.rigidNoiseSettings.weightMultiplier = Random.Range(0.5f, 0.9f);
                break;
        }

        foreach(S_ColorSettings.BiomeColorSettings.Biome biome in colorSettings.biomeColorSettings.biomes)
        {
            biome.gradient = gradients[Random.Range(0, gradients.Count)];
            biome.gradient.mode = (Random.Range(0, 1) == 0) ? GradientMode.Fixed : GradientMode.Blend;

            biome.tint = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            biome.startHeight = Random.Range(0.1f, 0.3f);
            biome.tintPercent = Random.Range(0.25f, 0.85f);
        }
    }

    /// <summary>
    /// Reset settings to default
    /// </summary>
    public void ResetSettings()
    {
        // Copy god's settings
        shapeSettings = new S_ShapeSettings(god.shapeSettings);
        colorSettings = new S_ColorSettings(god.colorSettings);
    }
}
