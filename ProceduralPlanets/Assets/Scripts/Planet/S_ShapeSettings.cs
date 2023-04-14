using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu()]
public class S_ShapeSettings : ScriptableObject
{
    public float planetRadius = 1.0f;
    public NoiseLayer[] noiseLayers;

    [System.Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public bool useFirstLayerAsMask;
        public S_NoiseSettings noiseSettings;
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="settings">Settings to copy</param>
    public S_ShapeSettings(S_ShapeSettings settings)
    {
        planetRadius = settings.planetRadius;
        noiseLayers = settings.noiseLayers;
    }
}