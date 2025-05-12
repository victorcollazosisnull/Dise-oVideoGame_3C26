using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioUIBinder : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {

            audioManager.masterSlider = masterSlider;
            audioManager.musicSlider = musicSlider;
            audioManager.sfxSlider = sfxSlider;


            float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

            masterSlider.value = masterVolume;
            musicSlider.value = musicVolume;
            sfxSlider.value = sfxVolume;

            masterSlider.onValueChanged.AddListener(audioManager.SetMasterVolume);
            musicSlider.onValueChanged.AddListener(audioManager.SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(audioManager.SetSFXVolume);
        }
        else
        {
            Debug.LogError("AudioManager no encontrado en la escena.");
        }
    }
}