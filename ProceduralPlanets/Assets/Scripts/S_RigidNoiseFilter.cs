using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RigidNoiseFilter : S_INoiseFilter
{
    private Noise noise = new Noise();
    private S_NoiseSettings.RigidNoiseSettings noiseSettings;

    public S_RigidNoiseFilter(S_NoiseSettings.RigidNoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0.0f;
        float frequency = noiseSettings.baseRoughness;
        float amplitude = 1;
        float weight = 1.0f;

        // iterate through all noise layers
        for (int i = 0; i < noiseSettings.numLayers; i++)
        {
            float v = 1.0f - Mathf.Abs(noise.Evaluate(point * frequency + noiseSettings.center));
            v *= v; // Make the peaks more pronounced
            v *= weight;

            weight = Mathf.Clamp01(v * noiseSettings.weightMultiplier); // Change weight for next layer

            noiseValue += v * amplitude;

            // Update values for every layer
            frequency *= noiseSettings.roughness;
            amplitude *= noiseSettings.persistance;
        }

        noiseValue = Mathf.Max(0.0f, noiseValue - noiseSettings.minValue);

        return noiseValue * noiseSettings.strength;
    }
}
