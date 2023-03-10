using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Planet : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;
    public bool autoUpdate = true;

    public enum FaceRandomMask
    {
        ALL,
        TOP,
        BOTTOM,
        LEFT,
        RIGHT,
        FRONT,
        BACK
    };
    public FaceRandomMask faceRandomMask;

    public S_ShapeSettings shapeSettings;
    public S_ColorSettings colorSettings;

    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colorSettingsFoldout;

    private S_ShapeGenerator shapeGenerator = new S_ShapeGenerator();
    private S_ColorGenerator colorGenerator = new S_ColorGenerator();

    [SerializeField, HideInInspector]
    private MeshFilter[] meshFilters;
    private S_TerrainFace[] terrainFaces;

    public void Init()
    {
        shapeGenerator.UpdateSettings(shapeSettings);
        colorGenerator.UpdateSettings(colorSettings);

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

                meshObject.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colorSettings.planetMaterial;

            terrainFaces[i] = new S_TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, dir[i]);
            
            bool renderFace = faceRandomMask == FaceRandomMask.ALL || ((int)faceRandomMask - 1 == i);
            meshFilters[i].gameObject.SetActive(renderFace);
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
        for(int i = 0; i < 6; i++)
        {
            if (meshFilters[i].gameObject.activeSelf)
            {
                terrainFaces[i].ConstructMesh();
            }
        }

        colorGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    /// <summary>
    /// Generate colors for all mesh filter materials
    /// </summary>
    public void GenerateColors()
    {
        colorGenerator.UpdateColors();
    }
}
