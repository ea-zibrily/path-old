using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponManager : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    public GameObject noAmmo;
    weaponShoot weaponS;


    private void Awake()
    {
        weaponS = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
    }

    private void Update()
    {
        ammoUI.text = weaponS.currentAmmo + ("/") + weaponS.currentMagazine;
        if (weaponS.currentAmmo <= 0 && weaponS.currentMagazine <= 0 && Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(noAmmoUICoroutine());
        }
    }

    IEnumerator noAmmoUICoroutine()
    {
        noAmmo.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        noAmmo.SetActive(false);
    }
}
