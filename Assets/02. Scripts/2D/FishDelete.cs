using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDelete : MonoBehaviour
{
    public GameObject deletefish;
    public GameObject newfish;

  
    private new AudioSource audio;
    public AudioClip Space;


    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.Space;
        this.audio.loop = false;
        this.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (L_pause.IsPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.audio.Play();

                deletefish.gameObject.SetActive(false);
                newfish.gameObject.SetActive(true);
            }
        }
    }
}
