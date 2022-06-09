using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class C_finshLoading : MonoBehaviour
{
    public Animator NextScene_animator;

    void Update()
    {
        Invoke("FadeOut", 5);
    }

    void FadeOut()
    {
        NextScene_animator.SetBool("FadeOut", true);
        Invoke("NextScene", 5);
    }
    void NextScene()
    {
        SceneManager.LoadScene("DayFinish");
    }

    // private float fTime = 0.0f;
    //
    //
    // void Start()
    // {
    //      fTime = 0.0f;
    // }
    //
    // void Update()
    // {
    //     fTime += Time.deltaTime;
    //
    //     if (fTime >= 8.0f)
    //     {
    //         SceneManager.LoadScene("DayFinish");
    //     }
    // }
    //
    // 
}
