using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHandler : MonoBehaviour
{
    int currweaponIndex;
    [SerializeField] int totalWeapon;

    public GameObject[] weap;
    public GameObject weapHolder;
    [SerializeField] GameObject currentWeap;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapon = weapHolder.transform.childCount;
        weap = new GameObject[totalWeapon];

        for (int i = 0; i < totalWeapon; i++)
        {
            weap[i] = weapHolder.transform.GetChild(i).gameObject;
            weap[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        weap[0].GetComponent<SpriteRenderer>().enabled = true;
        currentWeap = weap[0];
        currweaponIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currweaponIndex < totalWeapon - 1)
            {
                weap[currweaponIndex].GetComponent<SpriteRenderer>().enabled = false;
                currweaponIndex += 1;
                weap[currweaponIndex].GetComponent<SpriteRenderer>().enabled = true;
                currentWeap = weap[currweaponIndex];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currweaponIndex > 0)
            {
                weap[currweaponIndex].GetComponent<SpriteRenderer>().enabled = false;
                currweaponIndex -= 1;
                weap[currweaponIndex].GetComponent<SpriteRenderer>().enabled = true;
                currentWeap = weap[currweaponIndex];
            }

        }


    }
}
