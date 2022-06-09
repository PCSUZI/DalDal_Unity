using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spacebar : MonoBehaviour
{
    public Image m_SpaceBar_Image;
    public Image m_SpaceBar_Front;
    public GameObject fish;
    public GameObject newfish;


    private float m_fullSpace = 100;
    public float m_plusSpace = 25;


    void Start()
    {

        m_SpaceBar_Image = gameObject.GetComponent<Image>();
        m_fullSpace = 100;  // Space 총 게이지 
    }


    // Update is called once per frame
    void Update()
    {
        if (L_pause.IsPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && fish.activeInHierarchy == true)
                m_SpaceBar_Image.fillAmount -= m_plusSpace / m_fullSpace;


            if (m_SpaceBar_Image.fillAmount == 0)
            {
                fish.gameObject.SetActive(false);
                newfish.gameObject.SetActive(true);
            }
        }
    }
}
