using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCheck : MonoBehaviour
{
    public GameObject knife;
    public GameObject CurFish;
    public GameObject newFish;

    private AudioSource Good;
    private AudioSource Bad;

    public AudioClip GoodCut;
    public AudioClip BadCut;

    public bool colCheck = true;
    public bool Space = true;
    // Start is called before the first frame update
    void Start()
    {

        Good = gameObject.AddComponent<AudioSource>();
        Good.clip = GoodCut;
        Good.loop = false;

        Bad = gameObject.AddComponent<AudioSource>();
        Bad.clip = BadCut;
        Bad.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colCheck == true)
        {
            MoveKnife();
        }
        if (colCheck == false)
            StopKnife();
    }


    void MoveKnife()
    {
        transform.position = new Vector3(Mathf.Lerp(-3, 3, Mathf.PingPong(Time.time, 1)), transform.position.y,
                              transform.position.z);
        //-6~6까지 왔다갔다 < 왜 이렇게 되는지 잘 모르겠는데 *2로 되는 것 같음
        colCheck = true;
        Space = true;
    }

    void StopKnife()
    {
        Invoke("MoveKnife", 2);
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Line")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                this.Good.Play();
                CurFish.SetActive(false);
                newFish.SetActive(true);
            }
        }

        if (col.gameObject.tag != "Line")
        {
            if (Input.GetKeyDown(KeyCode.Q) && Space)
            {
            this.Bad.Play();
            colCheck = false;
            Space = false;
            }
        }
    }
    
}
