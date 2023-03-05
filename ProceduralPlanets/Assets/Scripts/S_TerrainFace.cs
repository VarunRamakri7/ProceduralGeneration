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

    /// <summary>
    /// Parameterized Constructor
    /// </summary>
    /// <param name="mesh"></param>
    /// <param name="resolution"></param>
    /// <param name="localUp"></param>
    public S_TerrainFace(Mesh mesh, int resolution, Vector3 localUp)
    {
        this.mesh= mesh;
        this.resolution = resolution;
        
        this.localUp = localUp;
        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }

    /// <summary>
    /// Construct a mesh with the sry attributes
    /// </summary>
    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int triangleIndex = 0;

        // Compute vertex
        for(int i = 0; i < resolution; i++)
        {
            for(int j = 0; j < resolution; j++)
            {
                int index = j + i * resolution;
                Vector2 percent = new Vector2(j, i) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - 0.5f) * axisB;
                vertices[index] = pointOnUnitCube;

                // Make triangles
                if (j != (resolution - 1) && i != (resolution - 1))
                {
                    // First triangle
                    triangles[triangleIndex] = i;
                    triangles[triangleIndex + 1] = i + resolution + 1;
                    triangles[triangleIndex + 2] = i + resolution;

                    // Second triangle
                    triangles[triangleIndex + 3] = i;
                    triangles[triangleIndex + 4] = i + 1;
                    triangles[triangleIndex + 5] = i + resolution + 1;

                    triangleIndex += 6;
                }
            }
        }

        // Update mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
