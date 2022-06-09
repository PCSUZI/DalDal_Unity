using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_Garibi : MonoBehaviour
{
    int tutorial_index = 0;

    public GameObject tutorial;
    public GameObject popup;


    public Image tutorial0;
    public Image tutorial1;
    public Image tutorial2;
    public Image tutorial3;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            tutorial_index += 1;
        }
        switch (tutorial_index)
        {
            case 1:
                tutorial0.enabled = false;
                tutorial1.enabled = true;
                break;
            case 2:
                tutorial1.enabled = false;
                tutorial2.enabled = true;
                break;
            case 3:
                tutorial2.enabled = false;
                tutorial3.enabled = true;
                break;
            case 4:
                Destroy(tutorial);
                popup.SetActive(true);
                break;
            default:
                break;
        }
        }
}
