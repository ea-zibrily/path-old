using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class weaponManager : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    public GameObject noAmmo;
    //[SerializeField] int weapIndex;
    //public GameObject totalWeapGO;
    public GameObject[] weapImage;
    weaponShoot weaponS;
    GameObject weaponObj;
    public cameraController controll;

    private void Awake()
    {
        weaponS = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
        weaponObj = GameObject.FindGameObjectWithTag("weapon");
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        //weapIndex = totalWeapGO.transform.childCount;
        //weaponSprite = new GameObject[weapIndex];

    }
    private void Update()
    {
        if (controll.fightScene)
        {
            ammoUI.gameObject.SetActive(true);
            if (weaponObj.GetComponent<SpriteRenderer>().enabled == true)
            {
                ammoUI.text = weaponS.currentAmmo + ("/") + weaponS.currentMagazine;
                if (weaponS.currentAmmo <= 0 && weaponS.currentMagazine <= 0 && Input.GetKeyDown(KeyCode.Z))
                {
                    StartCoroutine(noAmmoUICoroutine());
                }
                weapImage[0].SetActive(true);
                weapImage[1].SetActive(false);
            }
            else
            {
                ammoUI.text = " ";
                weapImage[0].SetActive(false);
                weapImage[1].SetActive(true);
            }
        }
        else
        {
            ammoUI.gameObject.SetActive(false);
        }

    }

    IEnumerator noAmmoUICoroutine()
    {
        noAmmo.SetActive(true);
        yield return new WaitForSeconds(0.45f);
        noAmmo.SetActive(false);
    }
}
