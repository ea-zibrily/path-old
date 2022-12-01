using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class speakerUI : MonoBehaviour
{
    public Image potrait;
    public TextMeshProUGUI fullName;
    public TextMeshProUGUI dialog;

    private dialogueCharacter speaker;
    public dialogueCharacter Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            potrait.sprite = speaker.characterSprite;
            fullName.text = speaker.characterName;
        }
    }

    public string Dialogue
    {
        get { return dialog.text; }
        set { dialog.text = value; }
    }

    public bool hasSpeaker()
    {
        return speaker != null;
    }
    public bool speakerIs(dialogueCharacter character)
    {
        return speaker == character;
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }
}
