using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int D_salmon = 0;
    public int D_godengeo = 0;
    public int D_yellowfish = 0;
    public int D_tunafish = 0;
    public int D_jogae = 0;

    public int MAIN_DAY = 1; //메인 날짜

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        D_salmon = 0;
        D_godengeo = 0;
        D_yellowfish = 0;
        D_tunafish = 0;
        D_jogae = 0;
    }

    public void FishData_Insert(int p_salmon , int p_godengeo ,int p_yellowfish, int p_tunafish, int p_jogae)
    {
        D_salmon = p_salmon;
        D_godengeo = p_godengeo;
        D_yellowfish = p_yellowfish;
        D_tunafish = p_tunafish;
        D_jogae = p_jogae;

    }

    public void initFishScore()
    {
        D_salmon = 0;
        D_godengeo = 0;
        D_yellowfish = 0;
        D_tunafish = 0;
        D_jogae = 0;

    }

}
