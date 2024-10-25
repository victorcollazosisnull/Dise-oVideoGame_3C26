using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerGroup musicAudioMixerGroup;
    public AudioClip menuMusic;
    public AudioClip gameplayMusic;

    private AudioSource audioSource;
    public static MusicManager Instance { get; private set; }
<<<<<<< HEAD

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
=======
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = musicAudioMixerGroup;
<<<<<<< HEAD
        PlayMenuMusic(); 
=======
        PlayMenuMusic();
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
    }

    public void PlayMenuMusic()
    {
<<<<<<< HEAD
        if (audioSource.clip != menuMusic) 
        {
            audioSource.Stop();
            audioSource.clip = menuMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
=======
        audioSource.Stop();
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
    }

    public void PlayGameplayMusic()
    {
<<<<<<< HEAD
        if (audioSource.clip != gameplayMusic) // Solo cambiar si no está ya reproduciendo
        {
            audioSource.Stop();
            audioSource.clip = gameplayMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

=======
        audioSource.Stop();
        audioSource.clip = gameplayMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
>>>>>>> fde198a38e86cf3e7b0bbaa9dd79e820967916fa
    public void StopAllMusic()
    {
        audioSource.Stop(); // Detiene la música que se está reproduciendo
    }
}