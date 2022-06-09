using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Popup : MonoBehaviour
{
    private AudioSource Sound;
    public AudioClip SoundClip;

    public GameObject popup;
    public Animator PopupUp;

    public Sprite Day2;
    public Sprite Day3;
    public Sprite Day4;
    public Sprite Day5;

    // Start is called before the first frame update
    void Start()
    {
 
        PopupUp = GetComponent<Animator>();
        switch (BoardManager.Day)
        {
            case 2:
                gameObject.GetComponent<Image>().sprite = Day2;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = Day3;
                break;
            case 4:
                gameObject.GetComponent<Image>().sprite = Day4;
                break;
            case 5:
                gameObject.GetComponent<Image>().sprite = Day5;
                break;

            default:
                break;
        }

        Time.timeScale = 1;
        Sound = gameObject.AddComponent<AudioSource>();
        Sound.clip = SoundClip;
        Sound.loop = false;
        this.Sound.Play();

        PopupUp.SetBool("UI_Popup_up", true);
        Invoke("PopupWait", 1);
    }

    void PopupWait()
    {
        Time.timeScale = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
        }
    }
}
