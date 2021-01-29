using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    PlayerControls controls;
    InputAction moveAction;
    public float moveSpeed = 10.0f;
    CharacterController characterController;
    //Vector2 move;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        controls = new PlayerControls();
        moveAction = controls.Player.Move;
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        //Vector2 delta = move * moveSpeed * Time.deltaTime;
        //Debug.Log("move: " + move.ToString());
        Vector3 moveForward = transform.forward * move.y * moveSpeed * Time.deltaTime;
        Vector3 moveSideways = transform.right * move.x * moveSpeed * Time.deltaTime;
        //transform.position += moveForward + moveSideways;
        characterController.Move(moveForward + moveSideways);
    }
}
