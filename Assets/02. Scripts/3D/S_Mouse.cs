using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Mouse : MonoBehaviour
{
    public float Mouse_High = 140.0f;
    bool High_state = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse_High < gameObject.transform.position.y && High_state==false)
        {
            GameObject.FindWithTag("Player").SendMessage("High_Mouse");
            High_state = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.FindWithTag("Player").SendMessage("Low_Mouse");
    }

    //마우스 초기화 하는 함수
    void Mouse_init()
    {
        High_state = false;
        gameObject.transform.position = new Vector3(1000.0f, 120.0f, 0.0f);
    }
}
