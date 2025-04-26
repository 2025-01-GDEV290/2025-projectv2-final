using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider;  // Drag your slider here
    public AudioSource backgroundMusic;  // If you have a specific audio source for music

    private void Start()
    {
        // Initialize slider value with the current volume
        volumeSlider.value = AudioListener.volume;

        // Add listener to adjust volume when the slider value changes
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    // This function gets called when the slider value changes
    public void UpdateVolume(float volume)
    {
        AudioListener.volume = volume;  // Set the global volume level

        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;  // If you want to adjust a specific AudioSource, like background music
        }
    }
}
