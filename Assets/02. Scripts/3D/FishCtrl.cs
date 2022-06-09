using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FishCtrl : MonoBehaviour
{

    public enum FishState { idle, run, die , follow, fight ,ipjil};

    public FishState fishState = FishState.idle;

    private Transform fishTr;
    public Transform playerTr;

    //플레이어의 상태에 따라 물고기 행동 달라질꺼임
    private PlayerCtrl _playerCtrl;

    //private NavMeshAgent nvAgent;
    private Vector3 run_moveVector;

    //입질 사정거리
    public float ipjilDist = 5.0f;
    //도망 사정거리
    public float followDist = 50.0f;
    //물고기의 사망 여부 ( 찌랑 충돌 여부 )
    private bool isDie = false;
    //물고기 속도
    public float fishSpeed = 7.0f;

    private AudioSource audioSource;
    public Animator Fish_animator;

    //물고기 입질 이동용 애니메이터
   // public Animator Fish_position_animator;

    //물고기 움직임 Test 용
    float moveSpeed = 1f;
    float moveDir = 0;
    float randRot = 0;


    bool move_animation = false;



    // Start is called before the first frame update
    void Start()
    {
        //물고기 tr 
        fishTr = this.gameObject.GetComponent<Transform>();
        //추격 대상 플레이어의 transform 할당
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _playerCtrl = GameObject.FindWithTag("Player").GetComponent<PlayerCtrl>();



        //일정한 간격으로 물고기의 행동 상태를 체크하는 코루틴 함수 실행
        StartCoroutine(this.CheckfishState());
        
        //몬스터의 상태에 따라 동작하는 루틴을 실행하는 코루틴 함수 실행
        StartCoroutine(this.fishAction());

        audioSource = GetComponent<AudioSource>();



        //test
        randRot = Random.Range(-1f, 1f);
        transform.localRotation = Quaternion.Euler(0f, 180f * randRot, 0f);

    }

    private void Update()
    {
       
    }

    IEnumerator CheckfishState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            //몬스터와 플레이어 사이의 거리 측정 
            float dist = Vector3.Distance(playerTr.position, fishTr.position);

            //입질 범위 이내로 들어왔는지 확인
            if (dist <= ipjilDist && (int)_playerCtrl.playerState == 1 && _playerCtrl.GoFight==false && _playerCtrl.follow_fish_check==true)
            {
                fishState = FishState.ipjil; //공격 상태
                _playerCtrl.playerState = PlayerCtrl.PlayerState.wait;
            }
            else if (dist <= followDist && (int)_playerCtrl.playerState==1&&_playerCtrl.GoFight==false && _playerCtrl.follow_fish_check==false) //추적거리 범위 이내로 들어왔는지 확인
            {
                fishState = FishState.follow; //추적상태
                _playerCtrl.follow_fish_check = true;
            }
            else if (_playerCtrl.GoFight==true && (int)_playerCtrl.playerState==2)
            {
                if (gameObject.tag == "FIGHTFISH")
                    fishState = FishState.fight;
                else
                    fishState = FishState.idle;
            }
         
        }
    }

    //몬스터의 상태값에 따라 적절한 동작을 수행하는 함수
    IEnumerator fishAction()
    {
        while (!isDie)
        {
            switch (fishState)
            {
                case FishState.idle:
                   
                    IdleAction();
                    break;

                case FishState.follow:
                    //추적 대상의 위치를 넘겨줌

                    // nvAgent.destination = playerTr.position;
                    FollowPlayer();
                    //Invoke("FollowPlayer", 2);

                    break;

                case FishState.run:

                   

                    break;

                case FishState.die:
                    
                    break;

                case FishState.ipjil:
                    // FollowPlayer();
                    FishipjilMove();
                    Fishipjil();
                    break;
            }

          //  fishTr.transform.rotation = Quaternion.LookRotation(moveVector);

            yield return null;
        }
    }

    void FishipjilMove()
    {
        fishTr.rotation = Quaternion.Slerp(fishTr.rotation, Quaternion.LookRotation(playerTr.position - fishTr.position), 2.0f * Time.deltaTime);

        
        // StartCoroutine(this.pjilAni());

    }

   

    void Fishipjil()
    {
        // Fish_position_animator.SetTrigger("P_IG");
        if (move_animation == false)
        {
            Fish_animator.SetBool("IPJIL",true);
            Fish_animator.SetBool("ANIIPJIL", true);

            move_animation = true;
        }
        if (move_animation == true)
        {
            if (Fish_animator.GetBool("IPJIL") == false) 
            {
                fishState = FishState.follow;
            }
        }
    }

    void FishDie()
    {
        fishState=FishState.die;
        Destroy(gameObject);
    }
   
    void FishRun()
    {
        fishState = FishState.run;
        Destroy(gameObject);
    }

    void FollowPlayer()
    {
        fishTr.rotation = Quaternion.Slerp(fishTr.rotation, Quaternion.LookRotation(playerTr.position - fishTr.position), 2.0f * Time.deltaTime);
        fishTr.position += fishTr.forward * fishSpeed * Time.deltaTime;
    }

    void IdleAction()
    {
        // fishTr.position += fishTr.forward * fishSpeed * Time.deltaTime;
        // 걸리는게 없으면 직진
        if (!Physics.Raycast(transform.position, transform.forward, 1f))
        {
            transform.Translate(Vector3.forward * fishSpeed * Time.smoothDeltaTime);
        }
        else
        {
            // 걸리는게 있으면 방향찾기 
            if (Physics.Raycast(transform.position, transform.forward, 1f))
            {
                moveDir = Random.Range(-1f, 1f);
                transform.Rotate(Vector3.up, 180f * moveDir);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((int)_playerCtrl.playerState == 3)
        {
            if (other.transform.tag == "Player")
            {

                if (gameObject.transform.tag == "SAIMON")
                {
                    _playerCtrl.FishType = 1;
                    _playerCtrl.fish_float = 0.25f;
                }
                if (gameObject.transform.tag == "GODENGEO")
                {
                    _playerCtrl.FishType = 2;
                    _playerCtrl.fish_float = 0.35f;
                }
                if(gameObject.transform.tag=="YELLOWFISH")
                {
                    _playerCtrl.FishType = 3;
                    _playerCtrl.fish_float = 0.3f;
                }
                if(gameObject.transform.tag== "TUNAFISH")
                {
                    _playerCtrl.FishType = 4;
                    _playerCtrl.fish_float = 0.2f;
                }


                gameObject.tag = "FIGHTFISH";


              
              GameObject.FindWithTag("GAMEUI").SendMessage("Fight_start_ui");
              GameObject.FindWithTag("MAINCAMERA").SendMessage("Fight_music");


               audioSource.Play();
               Fish_animator.SetBool("FIGHT", true);

                    //자식으로 바꾸기
              transform.SetParent(_playerCtrl.tr.transform);
               fishState = FishState.run;
               _playerCtrl.GoFight = true;

               
            }
        }
    }

}
