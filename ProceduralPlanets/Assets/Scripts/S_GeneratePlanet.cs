using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GeneratePlanet : MonoBehaviour
{
    [SerializeField]
    private S_Planet god;

    private S_ShapeSettings shapeSettings;
    private S_ColorSettings colorSettings;

    public void Start()
    {
        // Copy god's settings
        shapeSettings = new S_ShapeSettings(god.GetComponent<S_ShapeSettings>());
        colorSettings = new S_ColorSettings(god.GetComponent<S_ColorSettings>());
    }

    /// <summary>
    /// Randomly generate shape settings
    /// </summary>
    public void GenerateShapeSettings()
    {
        shapeSettings.planetRadius = Random.Range(1.0f, 5.0f);
        foreach(S_ShapeSettings.NoiseLayer noiseLayer in shapeSettings.noiseLayers)
        {
            noiseLayer.noiseSettings.simpleNoiseSettings.strength = Random.Range(0.1f, 0.85f);
        }
    }
}
