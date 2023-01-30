using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateAR : S_Weapon
{
    [SerializeField]
    private List<GameObject> barrels;
    [SerializeField]
    private List<GameObject> bodies;
    [SerializeField]
    private List<GameObject> grips;
    [SerializeField]
    private List<GameObject> magazines;
    [SerializeField]
    private List<GameObject> scopes;
    [SerializeField]
    private List<GameObject> sights;
    [SerializeField]
    private List<GameObject> stocks;

    // Start is called before the first frame update
    void Start()
    {
        weaponType = Type.AR;
    }

    public override GameObject Generate()
    {
        Debug.Log("Generating AR");

        GameObject ar = bodies[Random.Range(0, bodies.Count)];

        return ar;
    }
}
