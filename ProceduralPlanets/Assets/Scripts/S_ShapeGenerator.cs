using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ShapeGenerator
{
    private S_ShapeSettings settings;

    public S_ShapeGenerator(S_ShapeSettings settings)
    {
        this.settings = settings;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * settings.planetRadius;
    }
}
