using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_pause : MonoBehaviour
{
    public AudioSource audio;
    static public bool IsPause;
    public Sprite StartImg;
    public Sprite StopImg;
    void Start()
    {
        IsPause = false;    
    }

    public void OnClick()
    {
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
            audio.Pause();
            ChangeImage();
            return;
        }
        if (IsPause == true)
        {
            Time.timeScale = 1;
            IsPause = false;
            audio.Play();
            ChangeImage();
            return;
        }
    }

    void ChangeImage()
    {
        if(IsPause)
        gameObject.GetComponent<Image>().sprite = StartImg;

        if(!IsPause)
        gameObject.GetComponent<Image>().sprite = StopImg;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                audio.Pause();
                ChangeImage();
                return;
            }
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                audio.Play();
                ChangeImage();
                return;
            }
        }
    }
}
