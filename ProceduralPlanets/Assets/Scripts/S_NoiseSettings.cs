using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_NoiseSettings
{
    public enum FilterType
    {
        SIMPLE,
        RIGID
    };
    public FilterType filterType;

    [ConditionalHide("filterType", 0)]
    public SimpleNoiseSettings simpleNoiseSettings;
    [ConditionalHide("filterType", 1)]
    public RigidNoiseSettings rigidNoiseSettings;

    [System.Serializable]
    public class SimpleNoiseSettings
    {
        public float strength = 1.0f;

        [Range(1, 8)]
        public int numLayers = 1;

        public float baseRoughness = 1.0f;
        public float roughness = 2.0f;
        public float persistance = 0.5f;
        public Vector3 center;
        public float minValue;
    }

    [System.Serializable]
    public class RigidNoiseSettings : SimpleNoiseSettings
    {
        public float weightMultiplier = 0.8f;
    }
}