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
    GameObject weapon;
    private Type genType;

    // Start is called before the first frame update
    void Start()
    {
        gunParent = this.gameObject;
        weapon = null;
        genType = Type.NONE;
    }

    /// <summary>
    /// Generate gun by randomly picking modules
    /// </summary>
    public void GenerateGun()
    {
        if (weapon != null)
        {
            Destroy(weapon);
            weapon = null;
        }

        genType = (Type)Random.Range(1, 3); // Choose a weapon type randomly
        Debug.Log("Random type: " + genType.ToString());

        switch(genType)
        {
            case Type.AR:
                Debug.Log("AR");
                weapon = generateAR.Generate();
                break;
            case Type.SNIPER:
                Debug.Log("Sniper");
                weapon = generateSniper.Generate();
                break;
            case Type.CROSSBOW:
                Debug.Log("Crossbow");
                weapon = generateCrossbow.Generate();
                break;
        }

        weapon.transform.position = this.transform.position; // Set weapon position
        weapon.transform.SetParent(gunParent.transform); // Set weapon parent

        //Instantiate<GameObject>(weapon);
    }
}
