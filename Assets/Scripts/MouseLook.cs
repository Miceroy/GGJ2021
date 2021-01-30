using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    PlayerControls controls;
    InputAction lookAction;
    Transform playerBody;
    float xRotation;
    private void Start()
    {
        playerBody = GetComponent<Transform>().parent;
    }

    private void Awake()
    {
        controls = new PlayerControls();
        lookAction = controls.Player.Look;
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
        // Look
        //Debug.Log("lookAction: " + lookAction.ReadValue<Vector2>().ToString());
        Vector2 look = lookAction.ReadValue<Vector2>();
        float mouseX = look.x * mouseSensitivity * Time.deltaTime;
        float mouseY = look.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
