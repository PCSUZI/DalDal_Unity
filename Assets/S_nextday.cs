using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class S_nextday : MonoBehaviour
{
    //데이터매니저
    public DataManager Data_Manger;

    public AudioSource audioSource;

    private void Awake()
    {
        Data_Manger = GameObject.FindWithTag("DATA").GetComponent<DataManager>();
    }

    public void ButtonClick()
    {
        audioSource.Play();


        if (Data_Manger.MAIN_DAY == 5)
        {
            if (BoardManager.Gold < 100000)
                SceneManager.LoadScene("Ending3");

            if (BoardManager.Gold >= 100000 && BoardManager.Gold < 200000)
                SceneManager.LoadScene("Ending2");

            if (BoardManager.Gold >= 200000)
                SceneManager.LoadScene("Ending1");

            Data_Manger.MAIN_DAY = 1;
            BoardManager.Gold = 0;
            BoardManager.CorrectNPC = 0;
            BoardManager.FailNPC = 0;
        }
        else
        {
            Data_Manger.MAIN_DAY += 1;

            BoardManager.CorrectNPC = 0;
            BoardManager.FailNPC = 0;


            SceneManager.LoadScene("FishingLoaingScene");
        }


        }
    }

