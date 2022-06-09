using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFish : MonoBehaviour
{
    public Transform Fish1;
    public Transform Fish2;
    public Transform Fish3;
    public Transform Fish4;
    public Transform Fish5;
    public GameObject popup;

    public static CreateFish CF;

    public bool fishcheck = false;

    // Start is called before the first frame update
    void Start()
    {
        CF = this;

        if (BoardManager.Day != 1)
        popup.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (L_pause.IsPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !fishcheck && BoardManager.Onefish > 0)
            {
                L_FishUI.oneF--;
                BoardManager.Onefish--;
                Instantiate(Fish1, new Vector3(2.4f, -0.6f, -3.0f), Quaternion.identity);
                fishcheck = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && !fishcheck && BoardManager.Twofish > 0)
            {
                CreateFish.CF.fishcheck = false;
                BoardManager.Twofish--;
                Instantiate(Fish2, new Vector3(2.6f, -1.55f, -1f), Quaternion.identity);
                fishcheck = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !fishcheck && BoardManager.Threefish > 0)
            {
                L_FishUI.threeF--;
                BoardManager.Threefish--;
                Instantiate(Fish3, new Vector3(2.4f, -0.49f, -3.0f), Quaternion.identity);
                fishcheck = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && !fishcheck && BoardManager.Fourfish > 0)
            {
                L_FishUI.fourF--;
                BoardManager.Fourfish--;
                Instantiate(Fish4, new Vector3(2.4f, -0.49f, -3.0f), Quaternion.identity);
                fishcheck = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && !fishcheck && BoardManager.Fivefish > 0)
            {
                L_FishUI.fiveF--;
                BoardManager.Fivefish--;
                Instantiate(Fish5, new Vector3(2.4f, -0.49f, -3.0f), Quaternion.identity);
                fishcheck = true;
            }

        }
    }
}
