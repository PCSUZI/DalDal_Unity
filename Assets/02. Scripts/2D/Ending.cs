using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    int tutorial_index = 0;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    // Start is called before the first frame update
    void Start()
    {

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
                one.SetActive(false);
                two.SetActive(true);
                break;
            case 2:
                two.SetActive(false);
                three.SetActive(true);
                break;
            case 3:
                three.SetActive(false);
                four.SetActive(true);
                break;
            case 4:
                four.SetActive(false);
                five.SetActive(true);
                break;
            case 5:
                five.SetActive(false);
                six.SetActive(true);
                break;
            case 6:
                six.SetActive(false);
                seven.SetActive(true);
                break;
            case 7:
                SceneManager.LoadScene("Main");
                break;
        }

    }
}
