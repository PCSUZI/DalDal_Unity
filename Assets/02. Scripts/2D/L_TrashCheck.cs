using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_TrashCheck : MonoBehaviour
{


    public GameObject head;
    public GameObject tail;
    public GameObject Curfish;
    public GameObject Newfish;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (head.activeSelf==false && tail.activeSelf == false)
        {
            Curfish.SetActive(false);
            Newfish.SetActive(true);
        }
    }
}
