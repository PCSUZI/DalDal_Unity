using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    //튜토리얼
    public bool last_tutorialing = false;

    //데이터매니저
    public DataManager Data_Manger;

    //Text UI 항목 연결을 위한 변수
    public Text txtScore;

    //플레이어 상태 UI
    public Text playerState_text;

    //시간 관련
    public Image TimeImage;
    public float PlayTime = 60.0f;
    private float InitTime;
    public int View_PlayTime;


    //물고기 잡은거 보여주는 UI
    public Text t_Salmon;
    public Text t_godengeo;
    public Text t_yellowfish;
    public Text t_tunafish;
    public Text t_jogae;


    private int salmonScore = 0; //연어
    private int godengeoScore = 0; //고등어
    private int yellowfishScore = 0; //방어
    private int tunafishScore = 0; //참치
    private int jogaeScore = 0; //가리비

    //player의 깊이 변수 
    public float y = 60;
    //깊이 변수 초기값 
    private float inity;
    //Player의 Health bar 이미지
    public Image imgYbar;
    public Transform playerTr;

    //마우스 클릭바 이미지
    public Image imgMousebar;
    public Transform MouseTr;
    private float initMousey;


    //플레이어 상태 체크
    public int playerState;


    //애니메이터
    //싸우는 게임 유아이 있는지 없는지 여부
    public bool fight_ui_check = false;
    public Animator fish_animator;
    public Animator dada_animator;
    public Animator ui_animator;

    public Animator NextScene_animator;

    private AudioSource audioSource;
    public AudioClip Next_music;
    public AudioClip Win_music;
    public AudioClip lose_music;
    public AudioClip R_sound;


    //팝업관리
    public S_popup _popup;
    public PlayerCtrl _player;
    public S_day2tuto _sday2;

    //esc 체크
    bool check_esc = false;
    public GameObject esc_background;

    private void Start()
    {
        Cursor.visible = false;

        //PlayerState_Text(0);

        InitTime = PlayTime;
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Data_Manger = GameObject.FindWithTag("DATA").GetComponent<DataManager>();

        inity = (float)playerTr.position.y;
        initMousey = (float)MouseTr.position.y;
        MouseTr.transform.position = new Vector3(1000.0f, 120.0f, 0.0f);

        audioSource = GetComponent<AudioSource>();

        check_esc = false;
        //  DispScore(0);

    }
    public void DecreaseTime()
    {
        TimeImage.fillAmount = PlayTime / InitTime;
    }

    public void DispScore(int WhatFish) //연어는 1 고등어는 2 방어는 3 참치4  가리비5 아무것도 아니면 0
    {

        audioSource.clip = Win_music;
        audioSource.PlayOneShot(Win_music, 1.0f);


        if (WhatFish == 1)
            salmonScore += 1;
        if (WhatFish == 2)
            godengeoScore += 1;
        if (WhatFish == 3)
            yellowfishScore += 1;
        if (WhatFish == 4)
            tunafishScore += 1;
        if (WhatFish == 5)
            jogaeScore += 1;

        txtScore.text = "(Test용)\n 고등어: " + salmonScore.ToString() + "\n 연어: " + godengeoScore.ToString();

        t_Salmon.text =  salmonScore.ToString();
        t_godengeo.text = godengeoScore.ToString();
        t_yellowfish.text = yellowfishScore.ToString();
        t_tunafish.text = tunafishScore.ToString();
        t_jogae.text = jogaeScore.ToString();


        Data_Manger.FishData_Insert(salmonScore, godengeoScore,yellowfishScore,tunafishScore,jogaeScore);

    }

    public void Lose_Sound()
    {
        audioSource.clip = lose_music;
        audioSource.PlayOneShot(lose_music, 1.0f);
    }

   public void Rsound()
   {
        audioSource.clip = R_sound;
        audioSource.PlayOneShot(R_sound, 1.0f);
    }

    public void PlayerState_Text(int State)
    {
        switch (State)
        {
            case 0: //down
                playerState_text.text = "내려가는중 \n\n R: 초기화 ";

                break;
            case 1: //stop
                playerState_text.text = "기다리는중 \n\n R: 초기화";

                break;
            case 2: //go
                playerState_text.text = "싸움중";

                break;
            case 3:
                playerState_text.text = "물고기가!!";
                break;
            default:
                playerState_text.text = "내려가는중";
                break;
        }
    }

    private void Update()
    {
        imgYbar.fillAmount = (float)playerTr.position.y / (float)inity;
        imgMousebar.fillAmount = (float)MouseTr.position.y / (float)initMousey;
        DecreaseTime();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
            if (last_tutorialing == false)
        {

            if (Data_Manger.MAIN_DAY != 2)
            {
                if (_popup.popup == false)
                {
                    _popup.startpopup();
                    _player.No_ani_check = true;



                    if (Input.GetMouseButtonDown(0))
                    {
                        _popup.click();
                        _popup.popup = true;
                        _player.No_ani_check = false;
                    }

                }
            }
            else if (Data_Manger.MAIN_DAY == 2)
            {
                if (_popup.popup == false)
                {
                    _popup.startpopup();
                    _player.No_ani_check = true;

                }

                if (Input.GetMouseButtonDown(0))
                {
                    _sday2.check += 1;
                }


                switch (_sday2.check)
                {
                    case 1:
                    _popup.realbye();
                    _sday2.tuto1_load();
                    _popup.popup = true;
                    break;
                    case 2:
                    _sday2.tuto2_load();
                    break;
                    case 3:
                    _sday2.tuto3_load();
                    _player.No_ani_check = false;
                        break;
                }

           }

            if (_popup.popup == true)
            {
                if (PlayTime > 0.0f)
                {
                    PlayTime -= Time.deltaTime;
                    View_PlayTime = (int)PlayTime;

                }
                else
                {
                    Cursor.visible = true;
                    Next_scenefunction();
                 
                }

              }

           
        }




        goal_NextScene();




    }

     void Next_scenefunction()
    {
        NextScene_animator.SetBool("FadeOut", true);
        Cursor.visible = true;
        Invoke("NextMusic", 4);
        Invoke("NextScene", 5);
        
    }
       
 

    void Fight_start_ui()
    {
        fight_ui_check = true;
        fish_animator.SetTrigger("START");
        dada_animator.SetTrigger("START");
        ui_animator.SetTrigger("START");
    }

    void NextScene()
    {

        SceneManager.LoadScene("CookingLoadingScene");
    }

    void NextMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = Next_music;
            audioSource.Play();
        }
    }


    void goal_NextScene()
    {
        switch(Data_Manger.MAIN_DAY)
        {
            case 1:
                if (Data_Manger.D_godengeo>=2)
                {
                    Next_scenefunction();
                } 
                break;

            case 2:
                if (Data_Manger.D_godengeo >= 2 && Data_Manger.D_jogae>=4)
                {
                    Next_scenefunction();
                }
                break;

            case 3:
                if (Data_Manger.D_godengeo >= 2 && Data_Manger.D_jogae >= 4 && Data_Manger.D_yellowfish >= 3)
                {
                    Next_scenefunction();
                }
                break;

            case 4:
                if (Data_Manger.D_godengeo >= 2 && Data_Manger.D_jogae >= 4 &&Data_Manger.D_yellowfish>=3 && Data_Manger.D_salmon>=2)
                {
                    Next_scenefunction();
                }
                break;

            case 5:
                if (Data_Manger.D_godengeo >= 2 && Data_Manger.D_jogae >= 4 && Data_Manger.D_yellowfish >= 3 && Data_Manger.D_salmon >= 2 && Data_Manger.D_tunafish>=1)
                {
                    Next_scenefunction();
                }
                break;
        }
    }

    void Esc()
    {
        if (check_esc == false)
        {
            Cursor.visible = true;
            check_esc = true;
            Time.timeScale = 0;
            esc_background.SetActive(true);


        }
        else if(check_esc == true)
        {
            Cursor.visible = false;
            check_esc = false;
            Time.timeScale = 1;
            esc_background.SetActive(false);

        }
    }

    public void day5_skip()
    {
        Data_Manger.MAIN_DAY = 5;
        Data_Manger.D_godengeo = 0;
        Data_Manger.D_jogae = 0;
        Data_Manger.D_yellowfish = 0;
        Data_Manger.D_salmon = 0;
        Data_Manger.D_tunafish = 0;

        Time.timeScale = 1;
        SceneManager.LoadScene("3DFishScene_today5");
    }

    public void Main_skip()
    {
        Data_Manger.MAIN_DAY = 1;
        Data_Manger.D_godengeo = 0;
        Data_Manger.D_jogae = 0;
        Data_Manger.D_yellowfish = 0;
        Data_Manger.D_salmon = 0;
        Data_Manger.D_tunafish = 0;

        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

}
