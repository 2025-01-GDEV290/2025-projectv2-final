using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderDeactivation : MonoBehaviour
{
    public GameObject playerObject; // Reference to the Player
    public GliderRB gliderScript;     // Reference to the Glider script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gliderScript != null)
            {
                gliderScript.enabled = false; // Disable the Glider script
                Debug.Log("Glider disabled!");
            }
        }
    }
}
