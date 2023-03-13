using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class S_ColorSettings : ScriptableObject
{
    public Material planetMaterial;
    public BiomeColorSettings biomeColorSettings;

    [System.Serializable]
    public class BiomeColorSettings
    {
        public Biome[] biomes;
        public S_NoiseSettings noise;
        public float noiseOffset;
        public float noiseStrength;
        [Range(0.0f, 1.0f)]
        public float blendAmount;

        [System.Serializable]
        public class Biome
        {
            public Gradient gradient;
            public Color tint;
            [Range(0.0f, 1.0f)]
            public float startHeight;
            [Range(0.0f, 1.0f)]
            public float tintPercent;
        }
    }
}
