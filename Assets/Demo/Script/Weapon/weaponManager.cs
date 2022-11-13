using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponManager : MonoBehaviour
{
    public int ammoIndex;
    public int maxAmmo;
    public TextMeshProUGUI ammoUI;
    public GameObject noAmmo;
    weaponShoot weapon;


    private void Awake()
    {
        weapon = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
        ammoIndex = maxAmmo;
    }

    private void Update()
    {
        if (ammoIndex > 0)
        {
            useWeapon();
        }
        if (ammoIndex <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(noAmmoUICoroutine());
        }
    }

    void useWeapon()
    {
        if (weapon.isShoot)
        {
            ammoIndex -= 1;
        }
        ammoUI.text = ammoIndex + ("/") + maxAmmo;
    }

    IEnumerator noAmmoUICoroutine()
    {
        noAmmo.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        noAmmo.SetActive(false);
    }
}
