using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMelee : MonoBehaviour
{
    [Header("Scriptable Object")]
    public weaponMeleeDefinition _SOMelee;

    [Header("Attack Component")]
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    private float betweenTime;

    [Header("References")]
    Animator myAnim;

    void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        //attackRange = _SOMelee.meleeRadius;
        Debug.Log(attackRange);
    }

    void Update()
    {
        if (betweenTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myAnim.SetTrigger("attack");
                detectEnemy();
                betweenTime = _SOMelee.meleeBetweenAttack;
                Debug.Log(betweenTime);
            }
        }
        else
        {
            betweenTime -= Time.deltaTime;
        }
    }


    void detectEnemy()
    {
        foreach (Collider2D enemyCol in Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy))
        {
            Debug.Log("Enemy Detected");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
