using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip fireSound;
    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioClip gunSound;
    public AudioClip correctSound;
    private bool isGameOver = false;

    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            audioSource.Stop();
            audioSource.clip = gameOverSound;
            audioSource.Play();
        }
    }

    public void Respawn()
    {
        if (isGameOver)
        {
            isGameOver = false;
            PlayBackgroundMusic();
        }
    }
}
