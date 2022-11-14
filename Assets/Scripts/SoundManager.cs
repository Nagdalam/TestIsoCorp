using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance => instance;
    public AudioSource audioSrc;
    public AudioClip badSound, goodSound, endSound;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioToPlay)
    {
        audioSrc.PlayOneShot(audioToPlay);
    }
}
