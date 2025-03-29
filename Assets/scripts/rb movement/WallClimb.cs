using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    private Rigidbody rb;
    public float stickToWallForce = 5f; // How strong the forward force is when sticking to wall
    public float climbSpeed = 3f; // How fast you climb
    public float range = 1.5f; // Raycast range to detect walls

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure the Rigidbody is set for movement
    }

    void Update()
    {
        RaycastHit hit;

        // Perform a raycast in the forward direction
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Wall")) // If we hit a wall tagged "Wall"
            {
                if (Input.GetKey(KeyCode.Space)) // While holding Space, we can climb
                {
                    // Disable gravity to stop falling while climbing
                    rb.useGravity = false;

                    // Move the player forward (stick to the wall) and up (climb up)
                    Vector3 forwardMovement = transform.forward * stickToWallForce * Time.deltaTime;
                    Vector3 upwardMovement = transform.up * climbSpeed * Time.deltaTime;

                    // Apply movements to the Rigidbody for proper collision handling
                    rb.MovePosition(transform.position + forwardMovement + upwardMovement);
                }
            }
        }
        else
        {
            // Re-enable gravity when not climbing
            rb.useGravity = true;
        }
    }
}
