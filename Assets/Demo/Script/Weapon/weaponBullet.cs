using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBullet : MonoBehaviour
{

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        */
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
         Destroy(gameObject);
    }

}
