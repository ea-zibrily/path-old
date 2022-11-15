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
                //isShoot = true;
            }
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                //isShoot = false;
            }
        }
    }

    public void shoot()
    {
        bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        myRb = bullet.GetComponent<Rigidbody2D>();
        if (charaDir.isLeft)
        {
            myRb.AddForce((firePoint.right * -1) * _SOWeapDef.velocitySpeed, ForceMode2D.Impulse);
        }
        if (!charaDir.isLeft)
        {
            myRb.AddForce(firePoint.right * _SOWeapDef.velocitySpeed, ForceMode2D.Impulse);
        }
        weapManage.ammoIndex--;
    }
}
