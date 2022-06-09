using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_tutorial : MonoBehaviour
{
    int tutorial_index = 0;

    public GameObject tutorial;
    public GameObject popup;

    public GameObject garibi;

    public Image tutorial0;
    public Image tutorial1;
    public Image tutorial2;
    public Image tutorial3;
    public Image tutorial4;
    public Image tutorial5;
    public Image tutorial6;
    public Image tutorial7;
    public Image tutorial8;
    public Image tutorial9;
    public Image tutorial10;
    public Image tutorial11;
    public Image tutorial12;
    public Image tutorial13;
    public Image tutorial14;


    void Start()
    {
        Time.timeScale = 0;
        if (BoardManager.Day == 2)
        {
            garibi.SetActive(true);
            tutorial.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BoardManager.Day >= 3)
        {
            tutorial.SetActive(false);
        }
        
            if (Input.GetMouseButtonDown(0))
            {
                tutorial_index += 1;
            }

            switch (tutorial_index)
            {
                case 1:
                    tutorial0.enabled = false;
                    tutorial1.enabled = true;
                    break;
                case 2:
                    tutorial1.enabled = false;
                    tutorial2.enabled = true;
                    break;
                case 3:
                    tutorial2.enabled = false;
                    tutorial3.enabled = true;
                    break;
                case 4:
                    tutorial3.enabled = false;
                    tutorial4.enabled = true;
                    break;
                case 5:
                    tutorial4.enabled = false;
                    tutorial5.enabled = true;
                    break;
                case 6:
                    tutorial5.enabled = false;
                    tutorial6.enabled = true;
                    break;
                case 7:
                    tutorial6.enabled = false;
                    tutorial7.enabled = true;
                    break;
                case 8:
                    tutorial7.enabled = false;
                    tutorial8.enabled = true;
                    break;
                case 9:
                    tutorial8.enabled = false;
                    tutorial9.enabled = true;
                    break;
                case 10:
                    tutorial9.enabled = false;
                    tutorial10.enabled = true;
                    break;
                case 11:
                    tutorial10.enabled = false;
                    tutorial11.enabled = true;
                    break;
                case 12:
                    tutorial11.enabled = false;
                    tutorial12.enabled = true;
                    break;
                case 13:
                    tutorial12.enabled = false;
                    tutorial13.enabled = true;
                    break;
                case 14:
                    tutorial13.enabled = false;
                    tutorial14.enabled = true;
                    break;
                case 15:
                tutorial14.enabled = false;
                popup.SetActive(true);
                    break;

                default:
                    break;

            }// 1일차 튜토리얼
        
    }

}