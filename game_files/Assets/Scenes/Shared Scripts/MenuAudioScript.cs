using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioScript : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip backgroundMusic;

    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
