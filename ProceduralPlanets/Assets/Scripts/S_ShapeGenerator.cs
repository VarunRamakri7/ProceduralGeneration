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

    /// <summary>
    /// Calculate point on planet when given a point on a unit sphere
    /// </summary>
    /// <param name="pointOnUnitSphere"></param>
    /// <returns>Point on planet</returns>
    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * settings.planetRadius;
    }
}
