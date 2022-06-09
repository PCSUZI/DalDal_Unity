using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_FishUI : MonoBehaviour
{

    public Sprite FishImg0;
    public Sprite FishImg1;
    public Sprite FishImg2;
    public Sprite FishImg3;
    public Sprite FishImg4;


    public static int oneF = 4;
    public static int threeF = 4;
    public static int fourF = 4;
    public static int fiveF = 4;

    void Start()
    {
        oneF = 4;
        threeF = 4;
        fourF = 4;
        fiveF = 4;
    }
    void WhatIsFish(int n)
    {
        switch (n)
        {
            case 0:
                gameObject.GetComponent<Image>().sprite = FishImg0;
                break;
            case 1:
                gameObject.GetComponent<Image>().sprite = FishImg1;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = FishImg2;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = FishImg3;
                break;
            case 4:
                gameObject.GetComponent<Image>().sprite = FishImg4;
                break;
            default:
                break;
        }           
    }
    void ChangeImage()
    { 
        if (gameObject.tag == "GODENGEO")
        {
            WhatIsFish(oneF);
            if (oneF == 0)
            {
                BoardManager.TextOne--;

                if(BoardManager.TextOne > 0)
                {
                    oneF = 4;
                }
            }
            if (BoardManager.TextOne <= 0)
                BoardManager.TextOne = 0;
        }

        if (gameObject.tag == "YELLOWTAIL")
        {
            WhatIsFish(threeF);
            if (threeF == 0)
            {
                BoardManager.TextThree--;

                if (BoardManager.TextThree > 0)
                {
                    threeF = 4;
                }
            }
            if (BoardManager.TextThree <= 0)
                BoardManager.TextThree = 0;
        }

        if (gameObject.tag == "SAIMON")
        {
            WhatIsFish(fourF);
            if (fourF == 0)
            {
                BoardManager.TextFour--;

                if (BoardManager.TextFour > 0)
                {
                    fourF = 4;
                }
            }
            if (BoardManager.TextFour <= 0)
                BoardManager.TextFour = 0;
        }
        if (gameObject.tag == "Tuna")
        {
            WhatIsFish(fiveF);
            if (fiveF == 0)
            {
                BoardManager.TextFive--;

                if (BoardManager.TextFive > 0)
                {
                    fiveF = 4;
                }
            }
            if (BoardManager.TextFive <= 0)
                BoardManager.TextFive = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        ChangeImage();


    }
}
