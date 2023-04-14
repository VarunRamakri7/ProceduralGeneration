using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ShapeGenerator
{
    private S_ShapeSettings settings;
    private S_INoiseFilter[] noiseFilters;
    public S_MinMax elevationMinMax;

    public void UpdateSettings(S_ShapeSettings settings)
    {
        this.settings = settings;

        noiseFilters = new S_INoiseFilter[settings.noiseLayers.Length];
        for(int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = S_NoiseFilterFactory.CreateNosieFilter(settings.noiseLayers[i].noiseSettings);
        }

        elevationMinMax = new S_MinMax();
    }

    /// <summary>
    /// Calculate point on planet when given a point on a unit sphere
    /// </summary>
    /// <param name="pointOnUnitSphere"></param>
    /// <returns>Point on planet</returns>
    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = 0.0f;
        float elevation = 0.0f;

        if(noiseFilters.Length > 0)
        {
            firstLayerValue = noiseFilters[0].Evaluate(pointOnUnitSphere);
            if (settings.noiseLayers[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }

        for(int i = 1; i < noiseFilters.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask) ? firstLayerValue : 1.0f;
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }

        elevation = settings.planetRadius * (1.0f + elevation);

        elevationMinMax.AddValue(elevation);

        return pointOnUnitSphere * elevation;
    }
}
