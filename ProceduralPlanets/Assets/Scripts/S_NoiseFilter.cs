using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_NoiseFilter
{
    private Noise noise = new Noise();
    private S_NoiseSettings noiseSettings;

    public S_NoiseFilter(S_NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0.0f;
        float frequency = noiseSettings.baseRoughness;
        float amplitude = 1;

        // iterate through all noise layers
        for (int i = 0; i < noiseSettings.numLayers; i++)
        {
            float v = noise.Evaluate(point * frequency + noiseSettings.center);
            noiseValue += (v + 1.0f) * 0.5f * amplitude;

            // Update values for every layer
            frequency *= noiseSettings.roughness;
            amplitude *= noiseSettings.persistance;
        }

        noiseValue = Mathf.Max(0.0f, noiseValue - noiseSettings.minValue);

        return noiseValue * noiseSettings.strength;
    }
}
