using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertTrigger : MonoBehaviour
{
    public Animator alertAnim;
    public bool onDialogueArea;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            alertAnim.SetBool("alert", true);
            onDialogueArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            alertAnim.SetBool("alert", false);
            onDialogueArea = false;
        }
    }
}
