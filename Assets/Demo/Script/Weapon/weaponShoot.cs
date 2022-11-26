using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponShoot : MonoBehaviour
{
    [Header("Bullet Component")]
    public GameObject bulletPre;
    public Transform firePoint;
    public bool isShoot;


    [Header("Scriptable Object Component")]
    public weaponDefinition _SOWeapDef;


    [Header("Ammo")]
    public int currentAmmo;
    public int currentMagazine;

    [Header("Aim Targeting")]
    GameObject crossHair;
    Transform enemy;
    Vector2 lockTarget;


    [Header("Reference")]
    Rigidbody2D myRb;
    Animator myAnim;
    GameObject bullet;
    charaMove charaDir;


    void Awake()
    {
        myAnim = GetComponent<Animator>();
        charaDir = GameObject.Find("Chara").GetComponent<charaMove>();
        crossHair = GameObject.FindGameObjectWithTag("aim");
        enemy = GameObject.FindGameObjectWithTag("enemy").transform;
    }

    void Start()
    {
        currentAmmo = _SOWeapDef.weaponAmmo;
        currentMagazine = _SOWeapDef.weaponMagazine;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                myAnim.SetTrigger("shoot");
            }
        }
        if (currentAmmo <= 0)
        {
            //myAnim.SetTrigger("reload");
            weapReload();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //myAnim.SetTrigger("reload");
            weapReload();
        }

    }

    public void shoot()
    {
        Vector2 shootDir = charaDir.crossHair.transform.localPosition;
        shootDir.Normalize();
        Vector2 shootLockDir = charaDir.crossHair.transform.position;
        shootLockDir.Normalize();

        bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        myRb = bullet.GetComponent<Rigidbody2D>();

        if (charaDir.isLeft)
        {
            //myRb.AddForce((firePoint.right * -1) * _SOWeapDef.velocitySpeed, ForceMode2D.Impulse);
            myRb.velocity = shootDir * _SOWeapDef.velocitySpeed * -1;

            if (charaDir.isDown || charaDir.isUp)
            {
                myRb.velocity = shootDir * _SOWeapDef.velocitySpeed;
            }
        }
        if (!charaDir.isLeft)
        {
            //myRb.AddForce(firePoint.right * _SOWeapDef.velocitySpeed, ForceMode2D.Impulse);
            myRb.velocity = shootDir * _SOWeapDef.velocitySpeed;
        }

        currentAmmo--;
        Destroy(bullet, 5.5f);
    }

    void weapReload()
    {
        int reloadAmm = _SOWeapDef.weaponAmmo - currentAmmo;
        reloadAmm = (currentMagazine - reloadAmm) >= 0 ? reloadAmm : currentMagazine;

        currentAmmo += reloadAmm;
        currentMagazine -= reloadAmm;
    }

    public void addAmmo(int pickAmmo)
    {
        int sliceAmmo = pickAmmo - currentAmmo;
        int lostAmmo = pickAmmo - sliceAmmo;

        if (currentAmmo <= 0)
        {
            currentAmmo += pickAmmo;
        }

        if (currentAmmo > 0)
        {
            currentAmmo += sliceAmmo;
        }

        if (currentAmmo >= _SOWeapDef.weaponAmmo)
        {
            currentMagazine += lostAmmo;
        }

        if (currentMagazine > _SOWeapDef.weaponMagazine)
        {
            currentMagazine = _SOWeapDef.weaponMagazine;
        }
    }

    /*
    public void weapAiming()
    {
        lockTarget = enemy.position - transform.position;
        lockTarget.Normalize();

        crossHair.transform.position = enemy.position;
    }
    */
}
