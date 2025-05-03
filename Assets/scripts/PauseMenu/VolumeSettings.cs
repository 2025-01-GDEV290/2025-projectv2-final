using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [Header("Sliders")]
    public Slider ambientSlider;   // Controls ambient volume
    public Slider gameMusicSlider; // Controls game music volume

    [Header("Audio Sources")]
    public AudioSource ambientMusicSource;   // Ambient music audio source
    public AudioSource gameMusicSource;      // Game music audio source

    private void Start()
    {
        // Initialize slider values
        if (ambientSlider != null && ambientMusicSource != null)
        {
            ambientSlider.value = ambientMusicSource.volume;
            ambientSlider.onValueChanged.AddListener(UpdateAmbientVolume);
        }

        if (gameMusicSlider != null && gameMusicSource != null)
        {
            gameMusicSlider.value = gameMusicSource.volume;
            gameMusicSlider.onValueChanged.AddListener(UpdateGameMusicVolume);
        }
    }

    public void UpdateAmbientVolume(float volume)
    {
        if (ambientMusicSource != null)
            ambientMusicSource.volume = volume;
    }

    public void UpdateGameMusicVolume(float volume)
    {
        if (gameMusicSource != null)
            gameMusicSource.volume = volume;
    }
}
