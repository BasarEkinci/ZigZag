using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] List<AudioClip> soundEffects;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(int index)
    {
        audioSource.PlayOneShot(soundEffects[index]);
    }
    
    
}
