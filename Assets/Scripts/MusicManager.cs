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
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = musicAudioMixerGroup;
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        audioSource.Stop();
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayGameplayMusic()
    {
        audioSource.Stop();
        audioSource.clip = gameplayMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void StopAllMusic()
    {
        audioSource.Stop(); // Detiene la música que se está reproduciendo
    }
}