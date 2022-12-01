using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBullet : MonoBehaviour
{
    questManager questManager;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        questManager = GameObject.Find("QuestManager").GetComponent<questManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            questManager.questCompleted[0] = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
