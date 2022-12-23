using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Melee Weapon", menuName ="Weapon/New Melee Weapon", order = 1)]
public class weaponMeleeDefinition : ScriptableObject
{
    [Header("Basic Weapon Description")]
    public string meleeName;
    //public GameObject weaponObj;
    public WeaponType weaponType;
    public WeaponPassive meleePassive;

    [Multiline]
    //multiline dipake biar bisa add enter d inspector
    public string meleeDescription;

    [Header("Technical Melee Weapon Traits")]
    public int meleeDamage;
    public float meleeRadius;
    public float meleeBetweenAttack;
}
