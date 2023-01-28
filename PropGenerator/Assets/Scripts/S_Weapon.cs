using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enums for the types of possible weapons
public enum Type
{
    NONE,
    //PISTOL,
    AR,
    //GRENADE,
    CROSSBOW,
    SNIPER
    //SMG
};

public class S_Weapon : MonoBehaviour
{
    protected Type weaponType;
}