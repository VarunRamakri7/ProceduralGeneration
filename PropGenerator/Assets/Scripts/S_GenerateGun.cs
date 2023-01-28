using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateGun : MonoBehaviour
{
    enum Type
    {
        PISTOL,
        AR,
        GRENADE,
        SNIPER,
        CROSSBOW,
        SMG
    }

    [SerializeField]
    private List<GameObject> barrels;
    [SerializeField]
    private List<GameObject> accessories;
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

    private GameObject gunParent;

    // Start is called before the first frame update
    void Start()
    {
        gunParent = this.gameObject;
    }

    /// <summary>
    /// Generate gun by randomly picking modules
    /// </summary>
    public void GenerateGun()
    {

    }
}
