using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDemo : MonoBehaviour
{

    [Header("Reference")]
    public alertTrigger alertArea;

    public GameObject dialogueBox;

    // Update is called once per frame
    void Update()
    {
        if (alertArea.onDialogueArea)
        {
            dialogueBox.SetActive(true);
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }

}
