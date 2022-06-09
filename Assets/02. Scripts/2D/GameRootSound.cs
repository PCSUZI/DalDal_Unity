using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRootSound : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Space;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.Space;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (L_pause.IsPause == false)
        {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    this.audio.Play();
                }
        }
        
    }  
}
