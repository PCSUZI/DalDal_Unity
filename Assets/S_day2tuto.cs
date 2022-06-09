using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_day2tuto : MonoBehaviour
{
    public GameObject tuto1;
    public GameObject tuto2;

    public int check;

    // Start is called before the first frame update
    void Start()
    {
        check = 0;
        tuto1.SetActive(false);
        tuto2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tuto1_load()
    {
        tuto1.SetActive(true);
    }

    public void tuto2_load()
    {
        tuto1.SetActive(false);
        tuto2.SetActive(true);
    }

    public void tuto3_load()
    {
        tuto1.SetActive(false);
        tuto2.SetActive(false);
    }
}
