using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public GameObject Curfish;
    public GameObject Newfish;

    private AudioSource StartSound;
    public AudioClip Sound;

    IEnumerator LineBeat()
    {
        int countTime = 0;

        while (true)
        {
            if (countTime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
  
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSound = gameObject.AddComponent<AudioSource>();
        StartSound.clip = Sound;
        StartSound.loop = false;
        this.StartSound.Play();

        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine("LineBeat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Drag1")
        {
            Curfish.SetActive(false);
            Newfish.SetActive(true);
        }
        if (col.gameObject.tag == "Drag2")
        {
            Curfish.SetActive(false);
            Newfish.SetActive(true);
        }
    }

}
