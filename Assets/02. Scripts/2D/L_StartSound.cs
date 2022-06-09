using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_StartSound : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Sound;

    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject fish4;
    public GameObject fish5;

    public GameObject dish;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.Sound;
        this.audio.loop = false;
        this.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "GODENGEO" || gameObject.tag == "Scallops" || gameObject.tag == "YELLOWTAIL"
            || gameObject.tag == "SAIMON" || gameObject.tag == "Tuna")
        {
            if (!fish1.activeSelf && !fish2.activeSelf && !fish3.activeSelf &&
                !fish4.activeSelf && !fish5.activeSelf)
            {
                dish.SetActive(true);
            }
        }
    }
}
