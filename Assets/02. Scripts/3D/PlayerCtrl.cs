using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip spacemusic;
    public AudioClip rill_music;
    public AudioClip rill_no_music;


    private GameUI gameUI;

    public enum PlayerState { down, stop, go , wait };
    public PlayerState playerState = PlayerState.down;

    private float h = 0.0f;
    private float v = 0.0f;

    public Transform tr;
    private Rigidbody rg;


    public float moveSpeed = 10.0f;
    public float rotSpeed = 70.0f;
    public float downSpeed = 1.0f;
    public int hp = 100;
    public float Force = 50.0f;
    public float Down_Force = 1.0f;

    //바닥에 닿았는가 아닌가
    public bool IsFloor = false;
    //낚시 시작 
    public bool GoFight = false;
    private bool IsDie = false;
    public int FishType = 0; //물고기 타입 전송

    //마우스 클릭 부분
    public GameObject MouseBox;
    public Rigidbody MouseBoxrg;
    public float fish_float = 0.02f;
    public float Down_float = 0.009f;
    public float Mouse_Down = 20.0f;
    public float Mouse_Up = 5.0f;

    //애니메이터
    public Animator NOfish_animator;
    public Animator NOdada_animator;
    public bool No_ani_check = false;

    //플레이어한테 한마리만 가게 
    public bool follow_fish_check = false;


    //튜토리얼용 낚시 결과 전송용
    public int tutorial_result = 0; //1이 성공 2는 실패


    //메인 평화로운 음악
    bool Main_music = true;


    //줄에 따른 거
    public GameObject pin_move;
    public GameObject pin_pangpang;


    //가리비 잡는 키
    public bool Mouse_R = false;


    //델리게이트 및 이벤트 선언
    //public delegate void PlayerDieHandler();
    //public static event PlayerDieHandler OnPlayerDie;

    //[System.Serializable]
    //public class Anim
    //{
    //    public AnimationClip idle;
    //    public AnimationClip runForward;
    //    public AnimationClip runBackward;
    //    public AnimationClip runRight;
    //    public AnimationClip runLeft;
    //}

    //인스펙터뷰에 표시할 애니메이션 클래스 변수
    //public Anim anim;

    //아래에 있는 3D 모델의 Animation 컴포넌트에 접근하기 쉬운 변수 
    // public Animation _animation;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //스크립트 처음에 Transform 컴포넌트 할당
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();

        // _animation = GetComponentInChildren<Animation>();

        //_animation.clip = anim.idle;
        //_animation.Play();

        StartCoroutine(this.CheckPlayerState());

        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
        tutorial_result = 0;

        MouseBox.SetActive(false);

        pin_move.SetActive(true);
        pin_pangpang.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");



        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

        switch (playerState)
        {
            case PlayerState.down:

                if (No_ani_check == false)
                {
                   if(Main_music ==false)
                    {
                        GameObject.FindWithTag("MAINCAMERA").SendMessage("Main_music");
                        Main_music = true;
                    }

                    tr.Translate(Vector3.down * Time.deltaTime * downSpeed);
                    Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
                    //Translate 
                    tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

                    if(Input.GetMouseButton(1))
                    {
                        rg.transform.position += Vector3.up * 0.3f;
                        audioSource.clip = rill_no_music;
                        if (!audioSource.isPlaying)
                        {
                            audioSource.Play();
                        }

                        Mouse_R = true;

                        pin_move.SetActive(false);
                        pin_pangpang.SetActive(true);
                    }
                    else
                    {
                        audioSource.Stop();
                        Mouse_R = false;
                        pin_move.SetActive(true);
                        pin_pangpang.SetActive(false);
                    }

                    if (IsFloor == true)
                        PlayerInit();
                }
                

                break;
            case PlayerState.stop:


                break;

            case PlayerState.wait:

          

                break;
            case PlayerState.go:

                if (gameUI.fight_ui_check == false)
                {

                    tutorial_result = 0;
                    MouseBox.SetActive(true);

                    MouseBox.transform.Translate(Vector3.down * Time.deltaTime * 20);
                    rg.transform.position += Vector3.down * Down_float;
                    //  MouseBox.transform.Translate(Vector3.down * Time.deltaTime * 10);

                    if (Input.GetMouseButton(0))
                    {
                        //MouseBoxrg.AddForce(Vector3.up * Force);
                        MouseBox.transform.position += (Vector3.up * Mouse_Up);
                        rg.transform.position += Vector3.up * fish_float;

                        audioSource.clip = rill_music;
                        if (!audioSource.isPlaying)
                        {
                            audioSource.volume = 1.0f;
                            audioSource.Play();
                        }
                    }
                    else
                    {
                      
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        // MouseBox.transform.position -= (Vector3.down * Mouse_Down);
                        //MouseBox.transform.Translate(Vector3.down * 10);
                        MouseBoxrg.AddForce(Vector3.down * Mouse_Down, ForceMode.Impulse);

                       
                         audioSource.Stop();

                        audioSource.clip = rill_no_music;
                        if (!audioSource.isPlaying)
                        {
                            audioSource.volume=0.5f;
                            audioSource.Play();
                        }
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        MouseBoxrg.velocity = Vector3.zero;
                    }


                    if (rg.position.y >= 60.0f && GoFight == true)
                    {
                        tutorial_result = 1;
                        gameUI.DispScore(FishType);
                        GoFight = false;
                        GameObject.FindWithTag("FIGHTFISH").SendMessage("FishDie");
                        GameObject.FindWithTag("MAINCAMERA").SendMessage("Main_music");
                        PlayerInit();
                        GameObject.FindWithTag("MOUSE").SendMessage("Mouse_init");
                        MouseBox.SetActive(false);
                        audioSource.Stop();

                    }

                }
                // tr.Translate(Vector3.down * Time.deltaTime);
                break;
            default:
                break;
        }



    }



    IEnumerator CheckPlayerState()
    {
        while (!IsDie)
        {
            switch (playerState)
            {
                case PlayerState.down:

                    if (Input.GetKeyDown("space"))
                    {
                      //  gameUI.PlayerState_Text(1);
                        audioSource.clip = spacemusic;
                        audioSource.Play();
                        playerState = PlayerState.stop;

                    }
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        gameUI.Rsound();
                        PlayerInit();
                    }
                    break;
                case PlayerState.stop:


                    if (Input.GetKeyUp(KeyCode.R) && GoFight == false)
                    {

                        gameUI.Rsound();
                        PlayerInit();
                    }

                    break;
                case PlayerState.wait:

                    //  gameUI.PlayerState_Text(3);
                    if (Input.GetKeyUp(KeyCode.P))
                    {

                        gameUI.Rsound();
                        PlayerInit();
                    }



                    if (GoFight == true)
                    {
                        pin_move.SetActive(false);
                        pin_pangpang.SetActive(true);
                      //  gameUI.PlayerState_Text(2);
                        audioSource.clip = spacemusic;
                        audioSource.Play();
                        playerState = PlayerState.go;
                    }

                    break;
                case PlayerState.go:

                    break;
                default:
                    break;
            }



            yield return null;
        }
    }

    Vector3 InitPosition;
    //플레이어 초기화 함수
    public void PlayerInit()
    {
   
        InitPosition.Set(0, 60, 0);
        tr.transform.position = InitPosition;
        tr.transform.rotation.Set(0.0f, 0.0f, 0.0f, 0.0f);
        rg.velocity = Vector3.zero;
        rg.angularVelocity = Vector3.zero;
        rg.Sleep();

        IsFloor = false;
        playerState = PlayerState.down;
      //  gameUI.PlayerState_Text(0);
        FishType = 0;
        follow_fish_check = false;

        pin_move.SetActive(true);
        pin_pangpang.SetActive(false);

        rg.WakeUp();
    }

    //물고기 힘 함수
    void FishForce()
    {
        rg.AddForce(Vector3.down * Down_Force);
    }

    public void High_Mouse()
    {

        GameObject.FindWithTag("FIGHTFISH").SendMessage("FishRun");
        PlayerInit(); 
        NOdada_animator.SetTrigger("NO");
        No_ani_check = true;
        GoFight = false;
        GameObject.FindWithTag("MOUSE").SendMessage("Mouse_init");
        MouseBox.SetActive(false);
        //GameObject.FindWithTag("MAINCAMERA").SendMessage("Main_music");
        GameObject.FindWithTag("MAINCAMERA").SendMessage("Stop_Main_music");
        Main_music = false;
        gameUI.Lose_Sound();
        audioSource.Stop();        
        tutorial_result = 2;
    }

    void Low_Mouse()
    {
        
        GameObject.FindWithTag("FIGHTFISH").SendMessage("FishRun");
        PlayerInit();
        NOfish_animator.SetTrigger("NO");
        No_ani_check = true;
        GoFight = false; 
        GameObject.FindWithTag("MOUSE").SendMessage("Mouse_init");
        MouseBox.SetActive(false);
        GameObject.FindWithTag("MAINCAMERA").SendMessage("Stop_Main_music");
        Main_music = false;
        gameUI.Lose_Sound();
        audioSource.Stop();
        tutorial_result = 2;
    }

}

