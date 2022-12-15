using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Scriptable Object")]
    public playerDefinition _SOPlayerDefinition;

    [Header("Player Movement Component")]
    public float playerSpeed;
    public float playerSprintSpeed;
    [SerializeField] private float _playerOriginSpeed;
    public float playerOriginSpeed
    {
        get { return _playerOriginSpeed; }
        set { _playerOriginSpeed = value; }
    }
    public Vector2 playerDirection;
    public bool isSprint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
