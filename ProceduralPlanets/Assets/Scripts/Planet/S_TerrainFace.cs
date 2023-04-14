using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class S_TerrainFace
{
    private Mesh mesh;
    private int resolution;

    private Vector3 localUp;
    private Vector3 axisA;
    private Vector3 axisB;

    private S_ShapeGenerator ShapeGenerator;

    /// <summary>
    /// Parameterized Constructor
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="resolution"></param>
    /// <param name="localUp"></param>
    public S_TerrainFace(S_ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 localUp)
    {
        this.mesh= mesh;
        this.resolution = resolution;
        
        this.localUp = localUp;
        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);

        this.ShapeGenerator = shapeGenerator;
    }

    /// <summary>
    /// Construct a mesh with the sry attributes
    /// </summary>
    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int triangleIndex = 0;
        Vector2[] uv = mesh.uv;

        // Compute vertex
        for(int y = 0; y < resolution; y++)
        {
            for(int x = 0; x < resolution; x++)
            {
                int index = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2.0f * axisA + (percent.y - 0.5f) * 2.0f * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                vertices[index] = ShapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                // Make triangles
                if (x != (resolution - 1) && y != (resolution - 1))
                {
                    // First triangle
                    triangles[triangleIndex] = index;
                    triangles[triangleIndex + 1] = index + resolution + 1;
                    triangles[triangleIndex + 2] = index + resolution;

                    // Second triangle
                    triangles[triangleIndex + 3] = index;
                    triangles[triangleIndex + 4] = index + 1;
                    triangles[triangleIndex + 5] = index + resolution + 1;

                    triangleIndex += 6;
                }
            }
        }

        // Update mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        if (mesh.uv.Length == uv.Length)
        {
            mesh.uv = uv;
        }
    }

    public void UpdateUVs(S_ColorGenerator colorGenerator)
    {
        Vector2[] uv = new Vector2[resolution * resolution];

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int index = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2.0f * axisA + (percent.y - 0.5f) * 2.0f * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;

                uv[index] = new Vector2(colorGenerator.BiomePercentFromPoint(pointOnUnitSphere), 0.0f);
            }
        }

        mesh.uv = uv;
    }
}