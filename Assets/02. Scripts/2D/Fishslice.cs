using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishslice : MonoBehaviour
{
    public GameObject fishslice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (L_pause.IsPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fishslice.gameObject.SetActive(true);

            }
        }
    }
}
