using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class L_DataUI : MonoBehaviour
{


    public Text DayText;                // 일차
    public Text GoldText;               // 수익
    public Text NpcText;               // 하루에 남은 NPC 수
    public Text FailNPCText;          // 실패한 손님 수
    public Text CorrectNPCText;     // 물고기 판매량

   
    public Text score_first_fish;
    public Text score_second_fish;
    public Text score_third_fish;
    public Text score_four_fish;
    public Text score_five_fish;

    public Animator NextScene_animator;

    public int CorrectCnt = 0;
    public int GoldCnt = 0;
    public int FailCnt = 0;

    float timer;
    float waitT;


    void Start()
    {
        timer = 0.02f;
        waitT = 0.02f;
    }

    void NextScene()
    {
        SceneManager.LoadScene("DayEndLoadingScene");
    }
   
    void Counting()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "CookingScene")
        {
            score_first_fish.text = BoardManager.TextOne.ToString();
            score_second_fish.text = BoardManager.Twofish.ToString();
            score_third_fish.text = BoardManager.TextThree.ToString();
            score_four_fish.text = BoardManager.TextFour.ToString();
            score_five_fish.text = BoardManager.TextFive.ToString();
   
            if (BoardManager.npcCnt == 0 && RandomPos.Rand.pos1 && RandomPos.Rand.pos2 && RandomPos.Rand.pos3)
            { 
                NextScene_animator.SetBool("FadeOut", true);
                Invoke("NextScene", 5);
            }
            else if(BoardManager.totalfish == 0 && !CreateFish.CF.fishcheck)
            {
                NextScene_animator.SetBool("FadeOut", true);
                Invoke("NextScene", 5);
            }
        }
   
       // GoldText.text = "" + BoardManager.Gold;
       // DayText.text = "" + BoardManager.Day;
   
        if (SceneManager.GetActiveScene().name == "DayFinish")
        {
            timer += Time.deltaTime;

            if (timer > waitT)
            {
                if (CorrectCnt < BoardManager.CorrectNPC)
                {
                    CorrectCnt += 1;
                }
                else if (CorrectCnt == BoardManager.CorrectNPC)
                {
                    CorrectCnt = BoardManager.CorrectNPC;

                    if (FailCnt < BoardManager.FailNPC)
                    {
                        FailCnt += 1;
                    }
                else if (FailCnt == BoardManager.FailNPC)
                {
                    FailCnt = BoardManager.FailNPC;

                        if (GoldCnt < BoardManager.Gold)
                        {
                            GoldCnt += 1000;
                        }
                        else if (GoldCnt == BoardManager.Gold)
                            GoldCnt = BoardManager.Gold;
                    }
                }
                timer = 0;
            }



            FailNPCText.text = "" + FailCnt;
            CorrectNPCText.text = "" + CorrectCnt;
            GoldText.text = "" + GoldCnt;
            DayText.text = "" + BoardManager.Day;
        }
        if (SceneManager.GetActiveScene().name == "CookingScene")
        { 
          NpcText.text = BoardManager.npcCnt + " 명";
          GoldText.text = "" + BoardManager.Gold;
          DayText.text = "" + BoardManager.Day;
        }
    }
}  
