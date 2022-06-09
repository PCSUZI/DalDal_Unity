using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public Slider timeBar;
    public float maxTime = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBar.maxValue = maxTime;
        timeBar.value += Time.deltaTime * 5;
    }
}
