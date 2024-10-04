using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource; // The AudioSource for background music
    public AudioSource sfxSource;   // The AudioSource for sound effects

    [Header("UI Sliders")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        // Set default slider values
        musicVolumeSlider.value = musicSource.volume;
        sfxVolumeSlider.value = sfxSource.volume;

        // Add listeners to sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // Method to set music volume
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Method to set SFX volume
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
