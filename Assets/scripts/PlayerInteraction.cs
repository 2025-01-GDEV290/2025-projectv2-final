using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform teleportTarget; 
    public float interactionRange = 3f;
    public string interactableTag = "Interactable";

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            TryTeleport();
        }
    }

    private void TryTeleport()
    {
        
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
            
            
            CharacterController characterController = GetComponent<CharacterController>();

            if (characterController != null)
            {
                
                characterController.enabled = false;

                
                transform.position = teleportTarget.position;

                
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
