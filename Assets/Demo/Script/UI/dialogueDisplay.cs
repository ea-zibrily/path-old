using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueDisplay : MonoBehaviour
{
    public dialogueConversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;
    public bool convDone;

    speakerUI speakerUILeft;
    speakerUI speakerUIRight;
    int activeLineIndex = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {

    }
    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<speakerUI>();
        speakerUIRight = speakerRight.GetComponent<speakerUI>();
        speakerUILeft.Speaker = conversation.speakLeft;
        speakerUIRight.Speaker = conversation.speakRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            advanceConversation();
        }
    }

    void advanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            displayLine();
            activeLineIndex += 1;
            convDone = false;
        }
        else
        {
            speakerUILeft.hide();
            speakerUIRight.hide();
            activeLineIndex = 0;
            convDone = true;
        }
    }

    void displayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        dialogueCharacter character = line.character;

        if (speakerUILeft.speakerIs(character))
        {
            setDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            setDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }

    void setDialog(speakerUI activeSpeakerUI, speakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialogue = text;
        activeSpeakerUI.show();
        inactiveSpeakerUI.hide();
    }
}
