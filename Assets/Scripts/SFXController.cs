using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXController : MonoBehaviour
{
    public AudioMixerGroup sfxAudioMixerGroup;
    public AudioClip clickSound;
    public AudioClip damageSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;
    public AudioClip getCoins;
    public AudioClip explosion;
    public AudioClip tele;

    private AudioSource audioSource;

    public static SFXController Instance { get; private set; }

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
        audioSource.outputAudioMixerGroup = sfxAudioMixerGroup;
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayDamageSound()
    {
        audioSource.PlayOneShot(damageSound);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public void PlayGetCoin()
    {
        audioSource.PlayOneShot(getCoins);
    }
    public void PlayTeleport()
    {
        audioSource.PlayOneShot(tele);
    }

}
