using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : MonoBehaviour
{
    public float fallSpeed = 0f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGliding = false;

    public float gravity = -9.81f;  // Standard gravity
    public float glideGravity = -1f; // Reduced gravity when gliding

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player presses the Jump button and is not grounded (indicating gliding)
        if (Input.GetButton("Jump") && !controller.isGrounded)
        {
            isGliding = true;
        }
        else
        {
            isGliding = false;
        }

        if (isGliding)
        {
            // When gliding, limit the fall speed
            if (velocity.y < 0f && Mathf.Abs(velocity.y) > fallSpeed)
            {
                velocity.y = Mathf.Sign(velocity.y) * fallSpeed; // Limit the vertical speed to fallSpeed
            }

            velocity.y += glideGravity * Time.deltaTime;  // Apply reduced gravity when gliding
        }
        else
        {
            // Apply normal gravity when not gliding
            if (!controller.isGrounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0f;  // Reset vertical velocity when grounded
            }
        }

        // Move the character controller with the updated velocity
        controller.Move(velocity * Time.deltaTime);
    }
}
