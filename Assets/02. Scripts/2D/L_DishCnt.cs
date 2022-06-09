using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_DishCnt : MonoBehaviour
{
    private AudioSource Clean;
    private AudioSource Clear;
    private AudioSource Wash;

    public AudioClip Cleaning;
    public AudioClip Washing;
    public AudioClip ClearDish;

    public GameObject Dish;
    public GameObject bubble;
    public GameObject water;
    public GameObject CleanEff;
    public GameObject ClearEff;


    static public int CleanCnt;

    private bool CleanCheck = true;

    void Start()
    {

        Clean = gameObject.AddComponent<AudioSource>();
        Clean.clip = Cleaning;
        Clean.clip = ClearDish;
        Clean.clip = Washing;
        Clean.loop = false;

        Clear = gameObject.AddComponent<AudioSource>();
        Clear.clip = ClearDish;
        Clear.loop = false;

        Wash = gameObject.AddComponent<AudioSource>();
        Wash.clip = Washing;
        Wash.loop = false;
        Wash.volume = 0.2f;


        CleanCnt = 9;
    }
    void OnMouseDrag()
    {
        if (L_pause.IsPause == false && gameObject.tag != "Dish")
        {
            //마우스 좌표를 받아온다.
            Vector3 mousePosition
            = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            //마우스 좌표를 스크린 투 월드로 바꾸고 이 객체의 위치로 설정해 준다.
            this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }

    void Update()
    {
        if (CleanCnt == 0)
            CleanEff.SetActive(false);


        if (CleanEff.activeSelf == false && CleanCheck)
        {
            CleanCheck = false;

            if (!CleanCheck)
                DelDish();
        }
  
    }

    void DelDish()
    {
        this.Clear.Play();
        this.Wash.Pause();
        ClearEff.SetActive(true);
        CreateFish.CF.fishcheck = false;
        Destroy(Dish, 2);
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        if (L_pause.IsPause == false)
        {
            if (col.gameObject.tag == "Cleaner" && CleanCnt > 0)
            {
                bubble.SetActive(true);
                water.SetActive(true);
                this.Wash.Play();
                this.Clean.Play();
                CleanCnt--;
            }
        }

    }
}
