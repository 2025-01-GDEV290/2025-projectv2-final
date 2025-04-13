using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderUnlockZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player is tagged "Player"
        {
            MonoBehaviour glidingScript = other.GetComponentInChildren<GliderRB>(); // Replace with actual script name
            if (glidingScript != null)
            {
                glidingScript.enabled = true;
                Debug.Log("Glider Unlocked!");
            }

            // Optionally destroy the object or disable it after triggering
            Destroy(gameObject); // Or you can disable the collider to prevent retriggering
        }
    }
}
