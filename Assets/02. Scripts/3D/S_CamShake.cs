using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CamShake : MonoBehaviour
{
    public float ShakeAmount;

    float ShakeTime=0.0f;

    private PlayerCtrl _playerctrl;


    // Start is called before the first frame update
    void Start()
    {
        _playerctrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    // Update is called once per frame
    void Update()
    {

        if(ShakeTime>0)
        {
            transform.position += Random.insideUnitSphere * 0.3f;
            ShakeTime -= Time.deltaTime;
        }
       

        switch((int)_playerctrl.playerState)
        {
            case 0:
                if (Input.GetMouseButton(1))
                {
                    transform.position += Random.insideUnitSphere * 0.01f;
                }
                    break;

            case 1:
                break;

            case 2:
                if (Input.GetMouseButton(0))
                {
                    transform.position += Random.insideUnitSphere * ShakeAmount;
                }
                else
                {
                    transform.position += Random.insideUnitSphere * 0.01f;
                }

                break;

            case 3:
                break;

        }
        
        
    }
}
