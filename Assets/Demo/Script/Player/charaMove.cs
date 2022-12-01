using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    float oriSpeed;
    public float sprintSpeed;
    public bool isSprint, isLeft, isUp, isDown;


    [Header("Particle")]
    public GameObject dustPart;
    public Transform dustPoint;


    [Header("Aiming")]
    public GameObject crossHair;
    public GameObject crossHair2;
    public float crossHairRadius;

    public bool isLock;


    [Header("Player Statistic")]
    public Vector2 charaDir;
    public float dirSpeed;


    [Header("Target Area")]
    public Transform targetRad;
    public float radius;
    public LayerMask whatisTarget;

    [Header("Lock")]
    GameObject[] enemyObjs;
    public Transform target;
    public float radiusL;
    public LayerMask targets;


    [Header("Reference")]
    public charaManager manager;
    public cameraController controll;
    Rigidbody2D myRb;
    Animator myAnim;
    Animator weapAnim;
    SpriteRenderer mySprite;
    weaponShoot weapData;
    SpriteRenderer weapObj;


    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        weapData = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponShoot>();
        weapObj = GameObject.FindGameObjectWithTag("weapon").GetComponent<SpriteRenderer>();
        weapAnim = GameObject.FindGameObjectWithTag("weapon").GetComponent<Animator>();

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
        if (controll.fightScene)
        {
            crossHair.SetActive(false);
            if (weapObj.enabled == true)
            {
                crossHair.SetActive(true);
                if (Input.GetKeyDown(KeyCode.X) && isArea())
                {
                    lockTarget();
                }
                if (!isArea())
                {
                    aim();
                }
            }
            else
            {
                crossHair.SetActive(false);
            }
        }
        else
        {
            crossHair.SetActive(false);
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

        /// <summary>
        /// Old movement direction
        /// </summary>
        if (moveHori > 0 && isLeft)
        {
            transform.localScale = new Vector2(1, 1);
            //transform.eulerAngles = Vector2.zero;
            //mySprite.flipX = false;
            isLeft = false;
        }
        if (moveHori < 0 && !isLeft)
        {
            transform.localScale = new Vector2(-1, 1);
            //transform.eulerAngles = Vector2.up * 180;
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

        /*
        /// <summary>
        /// New Animation Sett
        /// </summary>

        if (charaDir != Vector2.zero)
        {
            myAnim.SetFloat("Horizontal", charaDir.x);
            myAnim.SetFloat("Vertical", charaDir.y);
            //myAnim.SetFloat("Magnitude", charaDir.magnitude);
            myAnim.SetBool("isMoving", true);

        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
        */


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
        Collider2D[] isEnemy = Physics2D.OverlapCircleAll(target.position, radiusL, targets);

        // Set first found
        Collider2D nearEnemy = null;
        float shortestDistance = Mathf.Infinity;

        for (int i = 0; i < isEnemy.Length; i++)
        {
            if (Vector3.Distance(crossHair.transform.position, isEnemy[i].transform.position) < shortestDistance)
            {
                //shortestDistance = newDist;
                nearEnemy = isEnemy[i];
                crossHair.transform.position = nearEnemy.transform.position;
                crossHair.transform.position = Vector2.MoveTowards(crossHair.transform.position, nearEnemy.transform.position, 3f);
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

    /*
            /// <summary>
            /// Old movement direction
            /// </summary>
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
        
        */
}
