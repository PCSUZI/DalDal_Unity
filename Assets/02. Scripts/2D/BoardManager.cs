using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{


    //데이터매니저
    public DataManager Data_Manger;


    //고등어 
    public static int Onefish = 0;
    public static int TextOne;
    //가리비
    public static int Twofish = 0;
    //방어
    public static int Threefish = 0;
    public static int TextThree;
    //연어
    public static int Fourfish = 0;
    public static int TextFour;
    //참치
    public static int Fivefish = 0;
    public static int TextFive;

    /////////////////////// 위에꺼는 수지 데이터 받아야 함 //////////////////////////

    public static int totalfish;                      // 종류 상관없이 물고기 총 합 ?> 0마리되면 게임종료

    public static int npcCnt;        // NPC 들어오는 수



    public static int Day = 1;                   // 며칠 차?
    public static int Gold = 0;            // 수익
    public static int CorrectNPC = 0;   // 물고기 판매 수
    public static int FailNPC = 0;        // 실패한 손님 수


    public void WhatIsDay(int n)
    {
        switch (n)
        {
            case 1:
                npcCnt = 8;
                break;
            case 2:
                npcCnt = 12;
                break;
           case 3:
                npcCnt = 24;
                break;
           case 4:
                npcCnt = 28;
                break;
           case 5:
                npcCnt = 32;
                break;

            default:
                break;
        }



   
    }

    void Awake()
    {
        Data_Manger = GameObject.FindWithTag("DATA").GetComponent<DataManager>();

        Day = Data_Manger.MAIN_DAY;
        WhatIsDay(Day); //밑으로 내리기

        

        DontDestroyOnLoad(this);


        TextOne = Data_Manger.D_godengeo; // Data_Manger.D_godengeo 바꾸고 밑으로 내리기
        Twofish = Data_Manger.D_jogae;
        TextThree = Data_Manger.D_yellowfish;
        TextFour = Data_Manger.D_salmon;
        TextFive = Data_Manger.D_tunafish;

        Onefish = TextOne * 4;
        Threefish = TextThree * 4;
        Fourfish = TextFour * 4;
        Fivefish = TextFive * 4;




    }

    void Start()
    {


    }
    void Update()
    {
        totalfish = Onefish + Twofish + Threefish + Fourfish + Fivefish;
    }

}
