using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_tutorial_Manager : MonoBehaviour
{
    
    bool tutorialing = false;
    int tutorial_index=0;

    public Image tutorial0;

    public Image tutorial1;
    public Image tutorial2;
    public Image tutorial3;
    public Image tutorial4;

    public Image tutorial7;
    public Image tutorial8;
    public Image tutorial9;

    public Image t_stop;

    public Image fight_tutorial1;
    public Image fight_tutorial2;

    public Image tutorial_succeed;
    public Image tutorial_fail;


    public Transform player;
    private PlayerCtrl player_script;
    private GameUI gameUI;

    // Start is called before the first frame update
    void Start()
    {
        player_script = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();

        gameUI.last_tutorialing = true;
        tutorialing = true;
        tutorial0.enabled = true;
        Time.timeScale = 0;

        tutorial_index = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameUI.last_tutorialing == true)
        {
            if (tutorialing == true)
            {
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
                        // tutorial2.enabled = false;
                        tutorial3.enabled = false;
                        tutorial4.enabled = true;
                        break;
                    case 5:
                        tutorial4.enabled = false;
                        Time.timeScale = 1;
                        tutorialing = false;
                        break;

                    case 6:

                        break;

                    case 7:
                        Time.timeScale = 0;
                        tutorial7.enabled = true;
                        break;
                    case 8: //R버튼 설명
                        tutorial7.enabled = false;
                        tutorial8.enabled = true;
                        break;
                    case 9:
                        tutorial8.enabled = false;
                        tutorial9.enabled = true;

                        break;
                    case 10:
                        tutorial9.enabled = false;
                        Time.timeScale = 1;
                        tutorialing = false;
                        break;

                    case 11:
                        Time.timeScale = 0;
                        t_stop.enabled = true;

                        break;
                    case 12:
                        t_stop.enabled = false;
                        Time.timeScale = 1;
                        tutorialing = false;
                        break;

                    case 13:
                        fight_tutorial1.enabled = true;
                        Time.timeScale = 0;
                        break;

                    case 14:
                        fight_tutorial1.enabled = false;
                        fight_tutorial2.enabled = true;
                        break;

                    case 15:
                        fight_tutorial2.enabled = false;
                        Time.timeScale = 1;
                        tutorialing = false;
                        break;


                    case 16: //낚시 성공
                        tutorial_succeed.enabled = true;
                        Time.timeScale = 0;
                        break;

                    case 17:
                        tutorial_succeed.enabled = false;
                        Time.timeScale = 1;
                        gameUI.last_tutorialing = false;
                        break;

                    case 18: //낚시 실패
                        tutorial_fail.enabled = true;
                        Time.timeScale = 0;
                        break;

                    case 19:
                        tutorial_fail.enabled = false;
                        tutorial_index = 9;
                        break;
                }
            }
            else if (tutorialing == false)
            {
                if (player.transform.position.y <= 55.0f && tutorial_index == 5)
                {
                    tutorialing = true;
                    tutorial_index = 7;
                }

                if ((int)player_script.playerState == 1 && tutorial_index == 10)
                {
                    tutorialing = true;
                    tutorial_index = 11;
                }

                if ((int)player_script.playerState == 2 && tutorial_index == 12 && gameUI.fight_ui_check == false)
                {
                    tutorialing = true;
                    tutorial_index = 13;
                }

                if ((int)player_script.playerState == 0 && tutorial_index == 15 && player_script.GoFight == false && player_script.tutorial_result > 0 && player_script.No_ani_check==false)
                {
                    switch (player_script.tutorial_result)
                    {
                        case 1:
                            tutorial_index = 16;
                            tutorialing = true;
                            player_script.tutorial_result = 0;
                            break;
                        case 2:
                            tutorial_index = 18;
                            tutorialing = true;
                            player_script.tutorial_result = 0;
                            break;

                    }
                }
            }
        }
    }
 
}
