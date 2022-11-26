using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    float oriSpeed;
    public float sprintSpeed;
    public bool isLeft, isUp, isDown;
    public bool isSprint, isMove;


    [Header("Particle")]
    public GameObject dustPart;
    public Transform dustPoint;


    [Header("Aiming")]
    public GameObject crossHair;
    public float crossHairRadius;
    GameObject[] enemyObjs;
    public bool isLock;


    [Header("Player Statistic")]
    public Vector2 charaDir;
    public float dirSpeed;


    [Header("Target Area")]
    public Transform targetRad;
    public float radius;
    public LayerMask whatisTarget;


    [Header("Reference")]
    public charaManager manager;
    Rigidbody2D myRb;
    Animator myAnim;
    SpriteRenderer mySprite;
    weaponShoot weapData;


    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        weapData = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
        isMove = true;

        enemyObjs = GameObject.FindGameObjectsWithTag("enemy");
    }


    void Start()
    {
        Debug.Log("Lesgo!");
        oriSpeed = moveSpeed;
        crossHairRadius = weapData._SOWeapDef.weaponRadius;
    }

    // Update is called once per frame
    void Update()
    {
        aim();

        if (Input.GetKeyDown(KeyCode.X) && isArea())
        {
            lockTarget();
        }
        
    }

    void FixedUpdate()
    {
        walk();
    }

    void walk()
    {
        float moveHori, moveVer;
        moveHori = Input.GetAxisRaw("Horizontal");
        moveVer = Input.GetAxisRaw("Vertical");

        //input proccess
        charaDir = new Vector2(moveHori, moveVer);
        dirSpeed = Mathf.Clamp(charaDir.magnitude, 0.0f, 1.0f);
        charaDir.Normalize();

        if (isMove)
        {
            /// <summary>
            /// setup sprint mechanic
            /// </summary>

            if (manager.hasGenerate)
            {
                if (Input.GetKey(KeyCode.LeftShift) && !isSprint && manager.energy >= 0)
                {
                    moveSpeed = sprintSpeed;
                    isSprint = true;
                    Debug.Log("ini speed sprint " + moveSpeed);
                }
            }

            if (!Input.GetKey(KeyCode.LeftShift) && isSprint)
            {
                moveSpeed = oriSpeed;
                isSprint = false;
                Debug.Log("ini speed normal " + moveSpeed);
            }

            //myRb.velocity = new Vector2((moveHori * moveSpeed), (moveVer * moveSpeed));
            myRb.velocity = charaDir * dirSpeed * moveSpeed;

            if (moveHori > 0 && isLeft)
            {
                //transform.localScale = new Vector2(1, 1);
                transform.eulerAngles = Vector2.zero;
                //mySprite.flipX = false;
                isLeft = false;
            }
            if (moveHori < 0 && !isLeft)
            {
                //transform.localScale = new Vector2(-1, 1);
                transform.eulerAngles = Vector2.up * 180;
                //mySprite.flipX = true;
                isLeft = true;
            }

            //Animation
            //left right
            if (moveHori != 0)
            {
                myAnim.SetTrigger("walk");
                isUp = false;
                isDown = false;
            }
            if (moveHori == 0 && !isUp && !isDown)
            {
                myAnim.SetTrigger("idle");
            }

            //up
            if (moveVer > 0)
            {
                myAnim.SetTrigger("up");
                isUp = true;
                isDown = false;
            }
            if (moveVer == 0 && isUp)
            {
                myAnim.SetTrigger("upidle");
            }

            //down
            if (moveVer < 0)
            {
                myAnim.SetTrigger("down");
                isDown = true;
                isUp = false;
            }
            if (moveVer == 0 && isDown)
            {
                myAnim.SetTrigger("downidle");
            }
        }
    }


    void aim()
    {
        if (charaDir != Vector2.zero)
        {
            crossHair.transform.localPosition = charaDir * crossHairRadius;

            if (charaDir.x < 0)
            {
                crossHair.transform.localPosition = new Vector2(charaDir.x * crossHairRadius * -1.0f, crossHair.transform.localPosition.y);
            }
        }
    }

    void lockTarget()
    {
        Collider2D[] isEnemy = Physics2D.OverlapCircleAll(targetRad.position, crossHairRadius, whatisTarget);

        // Set first found
        Collider2D nearEnemy = null;
        float shortestDistance = Mathf.Infinity;

        for (int i = 0; i < isEnemy.Length; i++)
        {
            if (Vector3.Distance(transform.position, isEnemy[i].transform.position) < shortestDistance)
            {
                //shortestDistance = newDist;
                nearEnemy = isEnemy[i];
                crossHair.transform.position = nearEnemy.transform.position;

            }
        }
    }

    bool isArea()
    {
        return Physics2D.OverlapCircle(targetRad.position, radius, whatisTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetRad.position, radius);
    }
}
