using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkInteraction : MonoBehaviour
{
    public GameObject interactIcon;
    private bool isPlayerInRange = false;

    void Update()
    {
        // When the player is in range
        if (isPlayerInRange)
        {
            if (!interactIcon.activeSelf)
            {
                interactIcon.SetActive(true);
                Debug.Log("Interaction Icon Active");
            }

            // If the player presses 'E' key
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player Pressed 'E'");
                ToggleInteraction();
            }
        }
        else
        {
            // Hide the interaction icon if player leaves range
            if (interactIcon.activeSelf)
            {
                interactIcon.SetActive(false);
                Debug.Log("Interaction Icon Inactive");
            }
        }
    }

    // Toggle behavior when the player presses 'E'
    private void ToggleInteraction()
    {
        Debug.Log("Radio Interaction Toggled");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player Entered Radio Range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player Left Radio Range");
        }
    }

    // Call this method after teleporting the player
    public void TeleportToTarget(Vector3 teleportPosition)
    {
        // Teleport the player to the new position
        transform.position = teleportPosition;

        // Disable the interaction icon after teleporting
        interactIcon.SetActive(false);
        Debug.Log("Interaction Icon Disabled after Teleportation");
    }
    
}
