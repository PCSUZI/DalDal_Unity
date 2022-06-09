using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_FishingLoading : MonoBehaviour
{


    //데이터매니저
    public DataManager Data_Manger;
    AsyncOperation oper1;

    public Animator _fadeout;

    private float fTime = 0.0f;

    bool load = false;

    void Start()
    {
        
        Data_Manger = GameObject.FindWithTag("DATA").GetComponent<DataManager>();

        StartCoroutine(LoadScene());

        fTime = 0.0f;
        load = false;



    }

    IEnumerator LoadScene()
    {
        yield return null;

            switch (Data_Manger.MAIN_DAY)
            {
                case 1:

                    oper1 = SceneManager.LoadSceneAsync("3DFishScene_today1");
                    oper1.allowSceneActivation = false;
                    Data_Manger.initFishScore();
                
                    break;
                case 2:
                    oper1 = SceneManager.LoadSceneAsync("3DFishScene_today2");
                    oper1.allowSceneActivation = false;
                    Data_Manger.initFishScore();
                    break;

                case 3:
                      oper1 = SceneManager.LoadSceneAsync("3DFishScene_today3");
                     oper1.allowSceneActivation = false;
                    Data_Manger.initFishScore();
                    break;

                case 4:
                     oper1 = SceneManager.LoadSceneAsync("3DFishScene_today4");
                      oper1.allowSceneActivation = false;
                    Data_Manger.initFishScore();
                    break;

                case 5:
                     oper1 = SceneManager.LoadSceneAsync("3DFishScene_today5");
                     oper1.allowSceneActivation = false;
                    Data_Manger.initFishScore();
                    break;
            }
        
        while(true)
        {
            yield return null;
            fTime += Time.deltaTime;

            if (fTime > 2.5f)
            {
                _fadeout.SetBool("FadeOut", true);
            }



            if (fTime > 6.0f)
            {

                if (!oper1.isDone)
                {
                    oper1.allowSceneActivation = true;
                }
            }


         }

    }

      

    }

 

