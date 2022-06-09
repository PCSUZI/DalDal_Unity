using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class S_cartoonMgr : MonoBehaviour
{
    AudioSource _audio;
    public AudioSource Main_audio;
    public AudioSource button_sound;

    public AudioClip sound_1_2;
    public AudioClip sound_1_3;
    public AudioClip sound_3_1;
    public AudioClip sound_3_3;
    public AudioClip sound_3_4;
    public AudioClip sound_3_5;
    public AudioClip sound_4;

    bool soundcheck=false;
    bool soundcheck2 = false;

    int cartoon_index = 1;

    public GameObject cartoon1_1;
    public GameObject cartoon1_2;
    public GameObject cartoon1_3;
    public GameObject cartoon1_4;

    public GameObject cartoon2_1;
    public GameObject cartoon2_2;
    public GameObject cartoon2_3;
    public GameObject cartoon2_4;

    public GameObject cartoon3_1;
    public GameObject cartoon3_2;
    public GameObject cartoon3_3;
    public GameObject cartoon3_4;
    public GameObject cartoon3_5;
    public GameObject cartoon3_6;

    public GameObject cartoon4;

    public GameObject button;
    public GameObject nextScene;

    public Animator NextScene_animator;


    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        cartoon_index = 1;
        soundcheck = false;
        soundcheck2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            cartoon_index += 1;
        }

        switch (cartoon_index)
        {
            case 1:
                cartoon1_1.SetActive(true);
                break;
            case 2:
                if (soundcheck == false)
                {
                    _audio.clip = sound_1_2;
                    _audio.Play();
                    soundcheck = true;
                 }


                cartoon1_2.SetActive(true);
                break;
            case 3:
                soundcheck = false;

                if (soundcheck2 == false)
                {
                    _audio.clip = sound_1_3;
                    _audio.Play();
                    soundcheck2 = true;
                }


                cartoon1_3.SetActive(true);
                break;
            case 4:
                soundcheck2 = false;
                cartoon1_4.SetActive(true);
                break;
            case 5:
                cartoon1_1.SetActive(false);
                cartoon1_2.SetActive(false);
                cartoon1_3.SetActive(false);
                cartoon1_4.SetActive(false);

                cartoon2_1.SetActive(true);
                break;
            case 6:
                cartoon2_2.SetActive(true);
                break;
            case 7:
                cartoon2_3.SetActive(true);
                break;
            case 8:
                cartoon2_4.SetActive(true);
                break;
            case 9:
                cartoon2_1.SetActive(false);
                cartoon2_2.SetActive(false);
                cartoon2_3.SetActive(false);
                cartoon2_4.SetActive(false);

                cartoon3_1.SetActive(true);

                if (soundcheck == false)
                {
                    _audio.clip = sound_3_1;
                    _audio.Play();
                    soundcheck = true;
                }

                break;
            case 10:

                soundcheck = false;

                cartoon3_2.SetActive(true);
                break;
            case 11:
                cartoon3_3.SetActive(true);

                if (soundcheck2 == false)
                {
                    _audio.clip = sound_3_3;
                    _audio.Play();
                    soundcheck2 = true;
                }


                break;
            case 12:
                soundcheck2 = false;
                if (soundcheck == false)
                {
                    _audio.clip = sound_3_4;
                    _audio.Play();
                    soundcheck = true;
                }

                cartoon3_4.SetActive(true);
                break;
            case 13:

                soundcheck = false;

                if (soundcheck2 == false)
                {
                    _audio.clip = sound_3_5;
                    _audio.Play();
                    soundcheck2 = true;
                }


                cartoon3_5.SetActive(true);
                break;
            case 14:
                soundcheck2 = false;
                cartoon3_6.SetActive(true);
                break;
            case 15:
                cartoon3_1.SetActive(false);
                cartoon3_2.SetActive(false);
                cartoon3_3.SetActive(false);
                cartoon3_4.SetActive(false);
                cartoon3_5.SetActive(false);
                cartoon3_6.SetActive(false);

                cartoon4.SetActive(true);
                button.SetActive(true);

                Main_audio.Stop();
                _audio.clip = sound_4;
                _audio.Play();

                cartoon_index += 1;
                break;
            default:
                break;
        }
    }

    public void buttonStartfunction()
    {
        nextScene.SetActive(true);
        NextScene_animator.SetBool("FadeOut", true);
        button_sound.Play();

        Invoke("NextScene", 5);
    }

    void NextScene()
    {
        SceneManager.LoadScene("FishingLoaingScene");
    }
}
