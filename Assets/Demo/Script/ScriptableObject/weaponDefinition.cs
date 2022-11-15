using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/New Weapon", order = 1)]
public class weaponDefinition : ScriptableObject
{
    [Header("Basic Weapon Description")]
    public string weaponName;
    //public GameObject weaponObj;
    public WeaponType weaponType;
    public WeaponPassive weaponPassive;

    [Multiline]
    //multiline dipake biar bisa add enter d inspector
    public string weaponDescription;

    [Header("Technical Weapon Traits")]
    public int weaponDamage;
    public int weaponAmmo;
    public int weaponMagazine;
    public float weaponRadius;
    public float velocitySpeed;
}


/// <summary>
/// cara buat bikin weapon data jadi banyak
/// </summary>

/*
//ini taruh main class
//public DataObject[] weaponData;

[System.Serializable]
public class DataObject
{
    public string weaponName;
    public WeaponType weaponType;
    public WeaponPassive weaponPassive;
    public int weaponDamage;
    public int weaponAmmo;
    public int weaponCost;
    public bool isLifeDrain;
    public bool isBaiter;
    public bool isDoubleType;
    public bool isLongRange;
}
*/
