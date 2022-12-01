using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line
{
    public dialogueCharacter character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue Component/New Conversation")]
public class dialogueConversation : ScriptableObject
{
    public dialogueCharacter speakRight;
    public dialogueCharacter speakLeft;
    public Line[] lines;
}
