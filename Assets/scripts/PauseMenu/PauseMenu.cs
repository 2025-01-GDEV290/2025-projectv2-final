using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI; // Reference to the Settings Panel

    public GameObject playerObject; // Reference to the player object
    public PlayerController playerControllerScript; // Player movement script
    public CameraController cameraControllerScript; // Camera controller script

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If settings is open, back out of it
            if (settingsMenuUI.activeSelf)
            {
                BackFromSettings();
            }
            else
            {
                if (isPaused)
                    Resume();
                else
                    Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false); // Just in case
        Time.timeScale = 1f;
        isPaused = false;

        // Re-enable player movement and camera control
        EnablePlayerScripts();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false); // Hide settings if open
        Time.timeScale = 0f;
        isPaused = true;

        // Disable player movement and camera control
        DisablePlayerScripts();
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void BackFromSettings()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    private void DisablePlayerScripts()
    {
        // Disable player movement and camera control
        if (playerControllerScript != null)
            playerControllerScript.enabled = false;

        if (cameraControllerScript != null)
            cameraControllerScript.enabled = false;
    }

    private void EnablePlayerScripts()
    {
        // Enable player movement and camera control
        if (playerControllerScript != null)
            playerControllerScript.enabled = true;

        if (cameraControllerScript != null)
            cameraControllerScript.enabled = true;
    }
    
}
