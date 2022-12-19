using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Scriptable Object")]
    public playerDefinition _SOPlayerDefinition;

    [Header("Player Movement Component")]
    [SerializeField] private string playerName;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerSprintSpeed;
    [SerializeField] private float playerOriginSpeed;
    public Vector2 playerDirection;
    public bool isSprint;

    [Header("Button Input")]
    public KeyCode[] inGameButton;

    [Header("Reference")]
    playerManager playerManager;
    Rigidbody2D myRb;
    Animator myAnim;

    private void Awake()
    {
        #region Game Component Reference
        playerManager = GetComponent<playerManager>();
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        #endregion

        #region Scriptable Object Reference
        playerName = _SOPlayerDefinition.playerName;
        playerSpeed = _SOPlayerDefinition.normalSpeed;
        playerSprintSpeed = _SOPlayerDefinition.sprintSpeed;
        #endregion
    }

    void Start()
    {
        playerOriginSpeed = playerSpeed;
    }

    void Update()
    {
        PlayerSprint();
    }

    private void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float moveX, moveY;
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(moveX, moveY);
        playerDirection.Normalize();

        myRb.velocity = playerDirection * playerSpeed;
        PlayerWalkAnimation();
    }

    void PlayerWalkAnimation()
    {
        if (playerDirection != Vector2.zero)
        {
            myAnim.SetFloat("moveX", playerDirection.x);
            myAnim.SetFloat("moveY", playerDirection.y);
            myAnim.SetBool("isWalk", true);

        }
        else
        {
            myAnim.SetBool("isWalk", false);
        }
    }

    void PlayerSprint()
    {
        isSprint = Input.GetKey(inGameButton[0]);
        if (playerManager.energyHasGenerated)
        {
            playerSpeed = isSprint ? playerSprintSpeed : playerOriginSpeed;
        }

        if (isSprint)
        {
            Debug.Log("Sprint Speed" + playerSpeed);
        }
        else
        {
            Debug.Log("Normal Speed" + playerSpeed);
        }

    }
}
