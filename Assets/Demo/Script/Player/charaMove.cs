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

    [Header("Reference")]
    public charaManager manager;
    Rigidbody2D myRb;
    Animator myAnim;
    SpriteRenderer mySprite;



    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        isMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lesgo!");
        oriSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("melee");
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
                    Debug.Log("ini speed sprint" + moveSpeed);
                }
            }

            if (!Input.GetKey(KeyCode.LeftShift) && isSprint)
            {
                moveSpeed = oriSpeed;
                isSprint = false;
                Debug.Log("ini speed normal" + moveSpeed);
            }

            myRb.velocity = new Vector2((moveHori * moveSpeed), (moveVer * moveSpeed));


            if (moveHori > 0 && isLeft)
            {
                transform.localScale = new Vector2(1, 1);
                //mySprite.flipX = false;
                isLeft = false;
            }
            if (moveHori < 0 && !isLeft)
            {
                transform.localScale = new Vector2(-1, 1);
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


    /// <summary>
    /// bikin method buat event animasi melee
    /// fungsinya biar player ga jalan pas nyerang
    /// </summary>

    void lockMove()
    {
        isMove = false;
    }

    void unlockMove()
    {
        isMove = true;
    }
}
