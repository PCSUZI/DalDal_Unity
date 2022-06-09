using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife1 : MonoBehaviour
{
    public GameObject fish;
    public GameObject knife;
    public GameObject knife2;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (L_pause.IsPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && fish.activeInHierarchy == true)
            {
                knife.SetActive(false);
                knife2.SetActive(true);
            }
        }
    }
}
