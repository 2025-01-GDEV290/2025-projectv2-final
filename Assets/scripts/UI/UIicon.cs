using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIicon : MonoBehaviour
{
    public GameObject interactIcon;
    private bool isPlayerInRange = false;

    void Update()
    {
        
        if (isPlayerInRange)
        {
            if (!interactIcon.activeSelf)
            {
                interactIcon.SetActive(true);
                Debug.Log("Interaction Icon Active");
            }

            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Player Pressed 'E'");
                ToggleInteraction();
            }
        }
        else
        {
           
            if (interactIcon.activeSelf)
            {
                interactIcon.SetActive(false);
                Debug.Log("Interaction Icon Inactive");
            }
        }
    }

    
    private void ToggleInteraction()
    {
        Debug.Log("Player Interaction Toggled");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player Entered Interaction Range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player Left Interaction Range");
        }
    }

    
    public void TeleportToTarget(Vector3 teleportPosition)
    {
        
        transform.position = teleportPosition;

       
        interactIcon.SetActive(false);
        Debug.Log("Interaction Icon Disabled after Teleportation");
    }
    
}
