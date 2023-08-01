using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    
    [SerializeField] public Boolean moving = false;

    private Animator animator;
    private Vector2 movementInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("moving", moving);
    }
    
    
    public void OnMove(InputValue value)
    {
        Debug.LogWarning("PlayerAnimation: On Move triggered ...");
        moving = true;
    }
    
    public void OnMoveEnd()
    {
        // Custom logic to handle the end of movement (e.g., stopping the player).
        // For example: Set velocity to zero, stop animations, etc.
        if (moving)
        {
            Debug.LogWarning("PlayerAnimation: On Move ended.");
            moving = false;
        }
    }
}
