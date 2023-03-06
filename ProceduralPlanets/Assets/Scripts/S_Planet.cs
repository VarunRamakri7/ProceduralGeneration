using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Planet : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;
    public bool autoUpdate = true;

    public S_ShapeSettings shapeSettings;
    public S_ColorSettings colorSettings;

    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colorSettingsFoldout;

    [SerializeField, HideInInspector]
    private MeshFilter[] meshFilters;
    private S_TerrainFace[] terrainFaces;

    private S_ShapeGenerator shapeGenerator;

    public void Init()
    {
        shapeGenerator = new S_ShapeGenerator(shapeSettings);

        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }

        terrainFaces = new S_TerrainFace[6];

        Vector3[] dir = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObject = new GameObject("Mesh");
                meshObject.transform.parent = transform;

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new S_TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, dir[i]);
        }
    }

    /// <summary>
    /// Reinit and generate mesh if shape settings are updated
    /// </summary>
    public void OnShapeSettingsUpdated()
    {
        if (autoUpdate)
        {
            Init();
            GenerateMesh();
        }
    }

    /// <summary>
    /// Reinit and generate colors if color settings are updated
    /// </summary>
    public void OnColorSettingsUpdated()
    {
        if (autoUpdate)
        {
            Init();
            GenerateColors();
        }
    }

    /// <summary>
    /// Initialize, generate mesh, and colors
    /// </summary>
    public void GeneratePlanet()
    {
        Init();
        GenerateMesh();
        GenerateColors();
    }

    /// <summary>
    /// Generate mesh for all terrain faces
    /// </summary>
    public void GenerateMesh()
    {
        foreach(S_TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    /// <summary>
    /// Generate colors for all mesh filter materials
    /// </summary>
    public void GenerateColors()
    {
        foreach(MeshFilter m in meshFilters)
        {
            m.GetComponent<MeshRenderer>().sharedMaterial.color = colorSettings.planetColor;
        }
    }
}
