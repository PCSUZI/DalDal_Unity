using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Collider2D Col;

    private AudioSource Good;
    private AudioSource Bad;

    public AudioClip GoodFish;
    public AudioClip BadFish;

    public GameObject curNPC;
    public GameObject idleNPC;
    public GameObject HappyNPC;
    public GameObject AngryNPC;

    public Slider timeBar;
    public float maxTime = 100;
    private bool timeOut = true;

    Vector3 pos;



    void Start()
    {

        timeBar.maxValue = maxTime;
        pos = transform.position;

        Good = gameObject.AddComponent<AudioSource>();
        Good.clip = GoodFish;
        Good.loop = false;

        Bad = gameObject.AddComponent<AudioSource>();
        Bad.clip = BadFish;
        Bad.loop = false;    
    }

    void Update()
    {
        if (timeOut)
        timeBar.value += Time.deltaTime * 5;

        if (timeBar.value == 100 && timeOut)
        {
            timeOut = false;

            if (timeOut == false)
                TimeOver();
        }
    }


    void TimeOver()
    {
        Col.enabled = false;
        this.Bad.Play();
        idleNPC.gameObject.SetActive(false);
        AngryNPC.gameObject.SetActive(true);
        Invoke("npcPosCheck", 2);
        BoardManager.FailNPC++;
     //   BoardManager.npcCnt--;
        RandomPos.Rand.spawncount++;

    }

    void npcPosCheck()
    {
        if (pos.x == -6.0f && pos.y == 0.75f && RandomPos.Rand.pos1 == false)
            RandomPos.Rand.pos1 = true;

        if (pos.x == 0.0f && pos.y == 0.75f && RandomPos.Rand.pos2 == false)
            RandomPos.Rand.pos2 = true;

        if (pos.x == 6.0f && pos.y == 0.75f && RandomPos.Rand.pos3 == false)
            RandomPos.Rand.pos3 = true;

        Destroy(curNPC);
    }

    void CollectFish()
    {
        Col.enabled = false;

        timeOut = false;

        this.Good.Play();
        idleNPC.gameObject.SetActive(false);
        HappyNPC.gameObject.SetActive(true);

        RandomPos.Rand.spawncount++;
        BoardManager.CorrectNPC++;

        Invoke("npcPosCheck", 2);
    }
    void WrongFish()
    {
        Col.enabled = false;

        timeOut = false;

        this.Bad.Play();
        idleNPC.gameObject.SetActive(false);
        AngryNPC.gameObject.SetActive(true);

        BoardManager.FailNPC++;
        RandomPos.Rand.spawncount++;
        Invoke("npcPosCheck", 2);
    }


    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject.tag == "GODENGEO") // 고등어
        {
            if (gameObject.tag == "Cat")
            {
                CollectFish();
                BoardManager.Gold += 1000;
            }
            if (gameObject.tag != "Cat")
                WrongFish();
        }

        if (col.gameObject.tag == "Scallops") // 가리비
        {
            if (gameObject.tag == "Penguin")
            {
                CollectFish();
                BoardManager.Gold += 3000;
            }
            if (gameObject.tag != "Penguin")
                WrongFish();
           
        }

        if (col.gameObject.tag == "YELLOWTAIL") // 방어
        {
            if (gameObject.tag == "Bird")
            {
                CollectFish();
                BoardManager.Gold += 5000;
            }
            if (gameObject.tag != "Bird")
                WrongFish();
        }
        if (col.gameObject.tag == "SAIMON") // 연어
        { 
            if (gameObject.tag == "Bird2")
            {
                CollectFish();
                BoardManager.Gold += 10000;
            }
            if (gameObject.tag != "Bird2")
                WrongFish();
        }
        if (col.gameObject.tag == "Tuna") // 새우
        {
            if (gameObject.tag == "Pen2")
            {
                CollectFish();
                BoardManager.Gold += 30000;
            }
            if (gameObject.tag != "Pen2")
                WrongFish();
        }
      // if (col.gameObject.tag == "Tuna") //참치
      // {
      //     if (gameObject.tag == "WhiteCat")
      //     {
      //         CollectFish();
      //         BoardManager.Gold += 30000;
      //     }
      //     if (gameObject.tag != "WhiteCat")
      //         WrongFish();
      // }

    }

   


}
