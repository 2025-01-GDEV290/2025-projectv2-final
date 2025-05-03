using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadEndingCutscene : MonoBehaviour
{
    public string sceneToLoad;          // Name of the scene to load
    public GameObject interactUI;       // UI prompt that says "Press E"
    private bool playerInRange = false; // Track if player is near the object

    private void Start()
    {
        if (interactUI != null)
            interactUI.SetActive(false); // Hide UI at start
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadNextScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactUI != null)
                interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactUI != null)
                interactUI.SetActive(false);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
