using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponShoot : MonoBehaviour
{
    [Header("Bullet Component")]
    public GameObject bulletPre;
    public Transform firePoint;
    public float bulletForce;
    public bool isShoot;

    [Header("Reference")]
    Rigidbody2D myRb;
    Animator myAnim;
    GameObject bullet;
    charaMove charaDir;
    weaponManager weapManage;


    void Awake()
    {
        myAnim = GetComponent<Animator>();
        charaDir = GameObject.Find("Chara").GetComponent<charaMove>();
        weapManage = GameObject.Find("Game Manager").GetComponent<weaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weapManage.ammoIndex > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myAnim.SetTrigger("shoot");
            }
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                isShoot = false;
            }
        }
    }

    void shoot()
    {
        bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        myRb = bullet.GetComponent<Rigidbody2D>();
        if (charaDir.isLeft)
        {
            myRb.AddForce((firePoint.right * -1) * bulletForce, ForceMode2D.Impulse);
            isShoot = true;
        }
        if (!charaDir.isLeft)
        {
            myRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            isShoot = true;
        }
    }
}
