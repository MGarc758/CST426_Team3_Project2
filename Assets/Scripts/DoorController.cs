using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioClip doorOpenSound;
    private void OnDestroy()
    {
        playDestroySound();
    }

    private void playDestroySound()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = doorOpenSound;
        audioSource.Play();

        // Destroy the AudioSource component after the sound has finished playing
        Destroy(audioSource, doorOpenSound.length);
    }
}
