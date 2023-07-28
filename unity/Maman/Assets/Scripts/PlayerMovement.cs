using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private float gravity = 9.81f;

    private Vector2 movementInput;

    private float moveDirection;
    private bool jump = false;
    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        moveDirection = movementInput.x * moveSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(moveDirection*Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    
    // This method is called from the PlayerInput component using the "sent messages" approach.
    public void OnMove(InputValue value)
    {
        Debug.LogWarning("On Move triggered...");

        // Get the movement input vector from the event.
        // The control type is set to "Vector2" in the PlayerInput component.
        movementInput = value.Get<Vector2>();
        
        Debug.LogWarning("On Move ended...");

    }

    public void OnJump()
    {
        Debug.LogWarning("On Jump triggered...");
        jump = true;

        Debug.LogWarning("On Jump ended...");
    }
}
