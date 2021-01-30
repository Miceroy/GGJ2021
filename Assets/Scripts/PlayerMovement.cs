using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

    Rigidbody body;
    PlayerControls controls;
    InputAction moveAction;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
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
        controls.Player.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        // Linear move
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 moveForward = transform.forward * move.y * moveSpeed * Time.deltaTime;
        Vector3 moveSideways = transform.right * move.x * moveSpeed * Time.deltaTime;
        characterController.Move(moveForward + moveSideways);
        characterController.Move(body.velocity * Time.deltaTime);

    }
}
