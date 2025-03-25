using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform teleportTarget; // Target location to teleport to
    public float interactionRange = 3f; // Distance at which player can interact with the object
    public string interactableTag = "Interactable"; // Tag of the object to interact with

    private void Update()
    {
        // When the player presses the 'E' key (you can change the key as needed)
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            TryTeleport();
        }
    }

    private void TryTeleport()
    {
        // Raycast to check if the player is facing an interactable object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                TeleportToTarget();
            }
        }
    }

    private void TeleportToTarget()
    {
        if (teleportTarget != null)
        {
            Debug.Log("Attempting to teleport to: " + teleportTarget.position);
            
            // Get the CharacterController component
            CharacterController characterController = GetComponent<CharacterController>();

            if (characterController != null)
            {
                // Temporarily disable the character controller to move the player
                characterController.enabled = false;

                // Set the player's position to the teleport target
                transform.position = teleportTarget.position;

                // Re-enable the character controller after teleporting
                characterController.enabled = true;

                Debug.Log("Teleported to: " + teleportTarget.name);
            }
            else
            {
                Debug.LogWarning("No CharacterController found on the player!");
            }
        }
        else
        {
            Debug.LogWarning("Teleport target not assigned!");
        }
    }
}
