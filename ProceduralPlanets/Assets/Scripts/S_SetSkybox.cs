using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class S_SetSkybox : MonoBehaviour
{
    [SerializeField]
    private List<Material> skyboxes;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, skyboxes.Count);
        RenderSettings.skybox = skyboxes[index];
    }
}
