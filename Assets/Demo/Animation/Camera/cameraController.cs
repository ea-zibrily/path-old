using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cameraController : MonoBehaviour
{
    public PlayableDirector[] enemy;
    public dialogueDisplay convCheck;
    public GameObject questPanel;
    public weaponHandler weapHandler;
    bool collOff;
    public bool fightScene;
    Animator cameraAnim;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        cameraAnim = GetComponent<Animator>();

    }

    private void Start()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].enabled = false;
        }
        fightScene = false;
    }
    private void Update()
    {
        if (convCheck.convDone && !collOff)
        {
            collOff = true;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }

        if (fightScene)
        {
            weapHandler.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].enabled = true;
            }
            cameraAnim.SetBool("coming", true);
            Invoke("backCam", 2.3f);
        }
    }

    void backCam()
    {
        cameraAnim.SetBool("coming", false);
        questPanel.SetActive(true);
        fightScene = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

}
