using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAim : MonoBehaviour
{
    GameObject[] enemyObjs;
    public Transform target;
    public float radius;
    public LayerMask targets;
    //List<Transform> enemy = new List<Transform>();

    private void Awake()
    {
        enemyObjs = GameObject.FindGameObjectsWithTag("enemy");

        /*
        var enemyObjs = GameObject.FindGameObjectsWithTag("enemy");
        foreach(var enemyObj in enemyObjs)
        {
            enemy.Add(enemyObj.transform);
        }
        */


    }
    
    void Update()
    {
        /*
        foreach(var enemyTrans in enemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyTrans.position, 3f);
        }
        */

        Collider2D[] isEnemy = Physics2D.OverlapCircleAll(target.position, radius, targets);

        // Set first found
        Collider2D nearEnemy = null;
        float shortestDistance = Mathf.Infinity;

        for (int i = 0; i < isEnemy.Length; i++)
        {
            if (Vector3.Distance(transform.position, isEnemy[i].transform.position) < shortestDistance)
            {
                //shortestDistance = newDist;
                nearEnemy = isEnemy[i];
                transform.position = nearEnemy.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, nearEnemy.transform.position, 3f);
            }
        }

    }
}
