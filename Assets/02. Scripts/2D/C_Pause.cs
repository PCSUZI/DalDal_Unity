﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Pause : MonoBehaviour
{
    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    { PauseUI.SetActive(false); }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        { paused = !paused; }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void ResumeGame()
    { paused = !paused; }

    public void QuitGame()
    {
        if (Input.GetMouseButtonDown(0))
            Application.Quit();
    }
}
