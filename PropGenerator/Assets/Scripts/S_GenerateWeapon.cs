using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GenerateWeapon : S_Weapon
{
    [SerializeField]
    private S_GenerateAR generateAR;
    [SerializeField]
    private S_GenerateCrossbow generateCrossbow;
    [SerializeField]
    private S_GenerateSniper generateSniper;

    private GameObject gunParent;
    private Type genType;

    // Start is called before the first frame update
    void Start()
    {
        genType = Type.NONE;
    }

    /// <summary>
    /// Generate gun by randomly picking modules
    /// </summary>
    public void GenerateGun()
    {
        genType = (Type)Random.Range(1, 3); // Choose a weapon type randomly
    }
}
