using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_popup : MonoBehaviour
{
    //팝업을 한번 띄웠는가 아닌가
    public bool popup = false;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startpopup()
    {
        gameObject.SetActive(true);
     
    }

    public void click()
    {
        ani.SetBool("Bye", true);
        Invoke("realbye",2.0f);
    }

    public void realbye()
    {
        gameObject.SetActive(false);
    }
}
