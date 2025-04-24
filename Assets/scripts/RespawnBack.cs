using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBack : MonoBehaviour
{
    public Transform respawnPoint; // assign this in inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;
            // Optional: reset velocity if using Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
