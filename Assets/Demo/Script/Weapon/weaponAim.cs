using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponAim : MonoBehaviour
{
    GameObject[] enemyObjs;
    List<Transform> enemy = new List<Transform>();

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyObjs[0].transform.position, 3f);


        /*
        foreach(var enemyTrans in enemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyTrans.position, 3f);
        }
        */
        

    }
}
