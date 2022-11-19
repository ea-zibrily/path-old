using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponManager : MonoBehaviour
{
    [SerializeField] int ammoIndex;
    [SerializeField] int magazineIndex;
    public TextMeshProUGUI ammoUI;
    public GameObject noAmmo;
    weaponShoot weaponS;


    private void Awake()
    {
        weaponS = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
        ammoIndex = weaponS.currentAmmo;
        magazineIndex = weaponS.currentMagazine;
    }

    private void Update()
    {
        ammoUI.text = weaponS.currentAmmo + ("/") + weaponS.currentMagazine;
        if (ammoIndex <= 0 && magazineIndex <= 0 && Input.GetKeyDown(KeyCode.Space))
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
