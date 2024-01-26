using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void playSF(AudioClip clip, Transform spawn, float volume)
    {
        // instantiate object
        AudioSource audioSource = Instantiate(soundFXObject, spawn.position, Quaternion.identity);


        // assign clip
        audioSource.clip = clip;

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // get length
        float length = audioSource.clip.length;


        // destroy the object

        Destroy(audioSource.gameObject, length);
    }
}
