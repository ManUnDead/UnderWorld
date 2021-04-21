using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Soundeffector : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound, coinSound, winSound, loseSound;
    public AudioSource musicSource, soundSource;

    private void Start()
    {
    musicSource.volume = (float) PlayerPrefs.GetInt("MusicVolume")/9;
    soundSource.volume = (float) PlayerPrefs.GetInt("SoundVolume")/9;
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }
}
