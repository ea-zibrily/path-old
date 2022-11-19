using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class charaManager : MonoBehaviour
{
    /*
    [Header("Health")]
    [HideInInspector] public float hp;
    public float maxHp;
    public GameObject[] bloodEffect;
    */

    [Header("Sprint Energy")]
    public float energy;
    public float maxEnergy;
    public float energyUse;
    public float energyGen;
    public float disSpeed;
    public bool hasGenerate;
    public Image energyBar;
    public Image energyEffect;

    [Header("Reference")]
    public charaMove chara;
    weaponShoot weapBullet;

    void Awake()
    {
        weapBullet = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
    }

    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        sprintEnergy();
    }

    void sprintEnergy()
    {

        if (Input.GetKey(KeyCode.LeftShift) && chara.isSprint && energy >= 0)
        {
            energy -= energyUse;
        }

        if (!chara.isSprint && energy <= maxEnergy)
        {
            energy += energyGen * Time.deltaTime;
            hasGenerate = false;
            if (energy >= maxEnergy)
            {
                hasGenerate = true;
            }
        }


        energyBar.fillAmount = energy / maxEnergy;

        if (energyEffect.fillAmount > energyBar.fillAmount)
        {
            energyEffect.fillAmount -= disSpeed;
        }
        else
        {
            energyEffect.fillAmount = energyBar.fillAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ammo"))
        {
            weapBullet.addAmmo(weapBullet._SOWeapDef.weaponAmmo);
            Destroy(other.gameObject);
        }        
    }
}
