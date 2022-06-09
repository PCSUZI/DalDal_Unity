using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{

    private int CatCnt = 8;
    private int PenCnt = 4;
    private int BirdCnt = 12;

    private int Bird2Cnt = 4;
    private int Pen2Cnt = 4;
 //   private int Cat2Cnt = 5;

    public GameObject Cat;
    public GameObject Bird;
    public GameObject Penguin;
    public GameObject Bird2;
    public GameObject Penguin2;
 //   public GameObject Cat2;


    public GameObject[] npcs = new GameObject[6];



    public static RandomPos Rand;

    public bool pos1 = true;        // 위치에 NPC 있는 지 체크
    public bool pos2 = true;        // 위치에 NPC 있는 지 체크
    public bool pos3 = true;        // 위치에 NPC 있는 지 체크


    public int spawn;
    public int spawncount = 3;      // 카운트 0이면 손님 못들어옴

    public int Daycheck;
    public int randCheck;

    public float maxspawnDelay;          // 스폰 최대

    //출력할지 말지
    public bool check = false;
  
    IEnumerator Hinpc()                 // NPC 들어오는 코루틴 
    {
        while (true)
        {
            
             yield return new WaitForSeconds(maxspawnDelay); // 딜레이 후

            if (spawncount >= 1) // 스폰 카운트가 1 이상이면
            {
                spawn = Random.Range(0, 3);    // pos 배열에 랜덤 (장소) 값 생성
                if (BoardManager.npcCnt > 0)
               Invoke( "SpawnNPC", 2);             // NPC 스폰한다
            }
        }
    }
 
    void Start()
    {
        Daycheck = BoardManager.Day; // DAY 값 가져오기 (랜덤값 미만으로 받아서)

        Rand = this;        // 스크립트 전역화

        if (spawncount <= 3 ) // 스폰 카운트가 3 이하면
        StartCoroutine("Hinpc"); // 손님 스폰 코루틴 시작


    }
    private void Update()
    {
        maxspawnDelay = Random.Range(1, 4); // 3~5초 사이에 손님 들어온다

    }


    void SpawnNPC()             // 손님 스폰
    {
        npcs[0] = Cat;
        npcs[1] = Penguin;
        npcs[2] = Bird;
        npcs[3] = Bird2;
        npcs[4] = Penguin2;

        randCheck = Random.Range(0, Daycheck);
       
        if (spawn == 0 && pos1) // 자리 체크
        {
          //  randCheck = Random.Range(0, Daycheck);
            WhatisNum();
            if (check == true)
            {
                pos1 = false;
                Instantiate(npcs[randCheck], new Vector3(-6.0f, 0.75f, 2.0f), Quaternion.identity);
                spawncount--;
                BoardManager.npcCnt--;

                check = false;
            }
        }
        if (spawn == 1 && pos2)
        {
         //   randCheck = Random.Range(0, Daycheck);
            WhatisNum();

            if (check == true)
            {
                pos2 = false;

                Instantiate(npcs[randCheck], new Vector3(0.0f, 0.75f, 2.0f), Quaternion.identity);
                spawncount--;
                BoardManager.npcCnt--;

                check = false;
            }
        }
        if (spawn == 2 && pos3)
        {
            WhatisNum();

            if (check == true)
            {
                pos3 = false;

                Instantiate(npcs[randCheck], new Vector3(6.0f, 0.75f, 2.0f), Quaternion.identity);
                spawncount--;
                BoardManager.npcCnt--;

                check = false;
            }
        }

        //npcs[Random.Range(0, 4)]
    }

   
    
    void WhatisNum()
    {

        if (randCheck == 0)
        {
            if (CatCnt > 0)
            {
                CatCnt--;
                check = true;
            }
            else if (CatCnt <= 0)
            {
                check = false;
            }
        }
        if (randCheck == 1)
        {
            if (PenCnt > 0)
            {
                PenCnt--;
                check = true;
            }
            else if (PenCnt <= 0)
            {
                check = false;
            }
        }
        if (randCheck == 2)
        {
            if (BirdCnt > 0)
            {
                BirdCnt--;
                check = true;
            }
            else if (BirdCnt <= 0)
            {
                check = false;
            }
        }
        if (randCheck == 3)
        {
            if (Bird2Cnt > 0)
            {
                Bird2Cnt--;
                check = true;
            }
            else if (Bird2Cnt <= 0)
            {
                check = false;
            }
        }
        if (randCheck == 4)
        {
            if (Pen2Cnt > 0)
            {
                Pen2Cnt--;
                check = true;
            }
            else if (Pen2Cnt <= 0)
            {
                check = false;
            }
        }
    }

   
}


