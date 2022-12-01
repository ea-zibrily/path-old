using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class questManager : MonoBehaviour
{
    public Image[] questIcon;
    public Color completeCol;
    public Color activeCol;
    public bool[] questCompleted;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < questCompleted.Length; i++)
        {
            if (questCompleted[i])
            {
                questIcon[i].color = completeCol;
            }
        }
    }

    void finishQuest()
    {
        questIcon[0].color = completeCol;
    }
}
