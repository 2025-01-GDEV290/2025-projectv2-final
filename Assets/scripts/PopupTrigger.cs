using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTrigger : MonoBehaviour
{
    public GameObject popupUI;
    public GameObject playerObject;

    private bool hasTriggered = false;

    private void Start()
    {
        popupUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            popupUI.SetActive(true);
            Time.timeScale = 0f;
            hasTriggered = true;

            // Disable movement and camera scripts
            playerObject.GetComponent<PlayerController>().enabled = false;
            playerObject.GetComponentInChildren<CameraController>().enabled = false; // <-- NEW
        }
    }

    public void OnOkButtonPressed()
    {
        popupUI.SetActive(false);
        Time.timeScale = 1f;

        // Enable movement and camera scripts
        playerObject.GetComponent<PlayerController>().enabled = true;
        playerObject.GetComponentInChildren<CameraController>().enabled = true; // <-- NEW
    }
}
