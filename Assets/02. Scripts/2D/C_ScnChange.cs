using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class C_ScnChange : MonoBehaviour
{

    public Button startButton;
    public Button ExitButton;

    public Animator button_ani;
    public Animator button_ani2;

    public float main_time = 6.0f;
    public float plus_time = 0.0f;

    public AudioSource _aud;

    public Animator _fadeout;


    public AudioSource _Main;
    public AudioClip _Bye;

    public GameObject NextScene;

    void Start()
    {
        startButton.enabled = false;
        ExitButton.enabled = false;
        NextScene.SetActive(false);

        BoardManager.Gold = 0;
        main_time = 8.0f;
        plus_time = 0.0f;
    }

    void Update()
    {
        plus_time += Time.deltaTime;

        if(main_time<plus_time)
        {
            startButton.enabled = true;
            ExitButton.enabled = true;
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("opencartoonScene");
        _aud.Play();
    }

    public void ExitGame()
    {
        _Main.clip = _Bye;  
        _Main.Play();
        NextScene.SetActive(true);
        _fadeout.SetBool("FadeOut", true);

        Invoke("exit", 3.0f);

    }

    public void buttonActive()
    {
        button_ani.SetBool("UI", true);
        button_ani2.SetBool("UI", true);
    }

    void exit()
    {
        Application.Quit();

    }
}
