using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController rb2D;
    private Vector2 movementInput;

    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        // Get the Rigidbody2D component attached to the "Player" game object (if any).
        rb2D = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the Rigidbody2D component is attached before using it.
        //if (rb2D.Equals(null))
        if (rb2D != null)
        {
            //Debug.LogWarning("Character controller component is OK.");

        }
        else
        {
            // If the Rigidbody2D component is not attached, you can handle it gracefully here
            // by printing a warning or adding the component programmatically, depending on your use case.
            Debug.LogWarning("Character controller component is missing from the Player game object.");
        }
    }
    
    // This method is called from the PlayerInput component using the "sent messages" approach.
    public void OnMove(InputValue value)
    {
        Debug.LogWarning("On Move triggered...");

        // Get the movement input vector from the PlayerInput component.
        // The control type is set to "Vector2" in the PlayerInput component, and action type is "Value".
        movementInput = value.Get<Vector2>();
        rb2D.SimpleMove(movementInput * moveSpeed);
        
        Debug.LogWarning("On Move ended...");

    }
}
