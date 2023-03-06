using System.Collections;
using System.Collections.Generic;
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
}