using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PlayUI : MonoBehaviour
{
    private PlayerCtrl _playerctrl;

    public GameObject down_state;
    public GameObject stop_state;
    public GameObject wait_state;
    public GameObject go_state;

    public Image down_key;
    public Image down_mouse;
    public Image down_r;
    public Image down_space;

    public Image go_mouse;

    public Image stop_r;


    // Start is called before the first frame update
    void Start()
    {
        _playerctrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();


        down_state.SetActive(true);
        stop_state.SetActive(false);
        wait_state.SetActive(false);
        go_state.SetActive(false);


        down_key.enabled = false;
        down_mouse.enabled = false;
        down_r.enabled = false;
        down_space.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ViewUI();
    }

   void ViewUI()
    {
        switch (_playerctrl.playerState)
        {
            case PlayerCtrl.PlayerState.down:

                down_state.SetActive(true);
                stop_state.SetActive(false);
                wait_state.SetActive(false);
                go_state.SetActive(false);

                if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
                {
                    down_key.enabled = true;
                   
                }
                else
                {
                    down_key.enabled = false;
                }


                if(Input.GetMouseButton(1))
                {
                    down_mouse.enabled = true;
                }
                else
                {
                    down_mouse.enabled = false;
                }

                if (Input.GetKey("space"))
                {
                    down_space.enabled = true;
                }
                else
                {
                    down_space.enabled = false;
                }

                if (Input.GetKey(KeyCode.R))
                {
                    down_r.enabled = true;
                }
                else
                {
                    down_r.enabled = false;
                }

                    break;
            case PlayerCtrl.PlayerState.stop:

                down_state.SetActive(false);
                stop_state.SetActive(true);
                wait_state.SetActive(false);
                go_state.SetActive(false);

                if (Input.GetKey(KeyCode.R))
                {
                    stop_r.enabled = true;
                }
                else
                {
                    stop_r.enabled = false;
                }

                break;
            case PlayerCtrl.PlayerState.go:

                down_state.SetActive(false);
                stop_state.SetActive(false);
                wait_state.SetActive(false);
                go_state.SetActive(true);

                if (Input.GetMouseButton(0))
                {
                    go_mouse.enabled = true;
                }
                else
                {
                    go_mouse.enabled = false;
                }
                    break;
            case PlayerCtrl.PlayerState.wait:

                down_state.SetActive(false);
                stop_state.SetActive(false);
                wait_state.SetActive(true);
                go_state.SetActive(false);

                break;
            default:
                break;
        }
    }
}
