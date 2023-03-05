using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Planet : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;

    [SerializeField, HideInInspector]
    private MeshFilter[] meshFilters;
    private S_TerrainFace[] terrainFaces;

    private void OnValidate()
    {
        Init();
        GenerateMesh();
    }

    public void Init()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }

        terrainFaces = new S_TerrainFace[6];

        Vector3[] dir = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for(int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObject = new GameObject("Mesh");
                meshObject.transform.parent = transform;

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new S_TerrainFace(meshFilters[i].sharedMesh, resolution, dir[i]);
        }
    }

    public void GenerateMesh()
    {
        foreach(S_TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
}
