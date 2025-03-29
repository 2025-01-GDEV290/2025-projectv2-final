using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform teleportTarget;  // The destination where the player will teleport
    public float interactionRange = 3f;  // How far the player can interact
    public string interactableTag = "Interactable";  // Tag for interactable objects
    public LayerMask ignoreLayerMask;  // LayerMask to specify which objects to ignore (like the mountain)

    private Rigidbody rb;  // Reference to the player's Rigidbody

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        // Cast a ray and ignore objects on the "Mountain" layer
        int layerMask = ~(1 << LayerMask.NameToLayer("Mountain"));  // Exclude the mountain layer from the raycast

        // Use the raycast to detect objects in the forward direction
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, layerMask))
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
            // Teleport the player by setting the position directly
            transform.position = teleportTarget.position;

            // Optional: reset velocity if necessary to avoid lingering motion after teleportation
            rb.velocity = Vector3.zero;
        }
        else
        {
            Debug.LogWarning("Teleport target not assigned!");
        }
    }
}