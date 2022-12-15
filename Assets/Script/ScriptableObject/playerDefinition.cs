using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerDefinition", menuName = "Player Definition/New Player Data", order = 1)]
public class playerDefinition : ScriptableObject
{
    public string playerName;
    public float speed;
    public float sprintSpeed;
}
