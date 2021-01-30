using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickItemFromScene : MonoBehaviour
{
    PlayerController player;
    PlayerControls controls;
    InputAction action1;
    InputAction action2;

    private void Awake()
    {
        controls = new PlayerControls();
        action1 = controls.Player.Action1;
        action2 = controls.Player.Action1;
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }


/*
    // Start is called before the first frame update
    void Start()
    {
        
    }
*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
