using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCutting : MonoBehaviour
{
    public GameObject fish;
    public GameObject tailCut;
    public GameObject headcut;
    public GameObject cutting;
    public GameObject cannon;

    private AudioSource audio;
    public AudioClip Hi;


    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.Hi;
        this.audio.loop = false;

        this.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tailCut.activeInHierarchy == false) // Q를 누를 때, 여러 번 눌러서 그림 뜨게 하는거 방지
        {
            fish.gameObject.SetActive(false);
            headcut.gameObject.SetActive(true);
            this.audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Q) && headcut.activeInHierarchy == true) // E를 누를 때, 여러 번 눌러서 그림 뜨게 하는거 방지 
        {
          fish.gameObject.SetActive(false);
            tailCut.gameObject.SetActive(true);
            headcut.gameObject.SetActive(false);
            this.audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && tailCut.activeInHierarchy == true)
        {
            cutting.gameObject.SetActive(false);
            cannon.gameObject.SetActive(true);
        }
     }
}
