using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class C_CookingLoading : MonoBehaviour
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
        SceneManager.LoadScene("CookingScene");
    }

    //bool IsDone = false;
    //float fTime = 0f;
    //AsyncOperation async_operation;
    //
    //void Start()
    //{
    //    StartCoroutine(StartLoad("CookingScene"));
    //}
    //
    //void Update()
    //{
    //    fTime += Time.deltaTime;
    //
    //    if (fTime >= 5)
    //    {
    //        async_operation.allowSceneActivation = true;
    //    }
    //}
    //
    //public IEnumerator StartLoad(string strSceneName)
    //{
    //    async_operation = SceneManager.LoadSceneAsync(strSceneName);
    //    async_operation.allowSceneActivation = false;
    //
    //    if (IsDone == false)
    //    {
    //        IsDone = true;
    //
    //        while (async_operation.progress < 0.9f)
    //        {
    //            yield return true;
    //        }
    //    }
    //}




}
