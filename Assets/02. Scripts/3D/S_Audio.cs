using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Audio : MonoBehaviour
{

    public AudioClip main_music;
    public AudioClip fight_music;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        audioSource.clip = main_music;
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fight_music()
    {
        audioSource.Pause();
        audioSource.volume = 0.3f;
        audioSource.clip = fight_music;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Main_music()
    {
        audioSource.Pause();
        audioSource.volume = 1.0f;
        audioSource.clip = main_music;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Stop_Main_music()
    {
        audioSource.Pause();
    }
}
