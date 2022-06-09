using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private Vector3 pos;

    private AudioSource Sound;
    public AudioClip SoundOn;


    public GameObject fish;
    public GameObject trash;

    public GameObject Curfish;
    public GameObject Newfish;

    public GameObject trashEff;

    public GameObject Washing;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        pos = gameObject.transform.position;

        Sound = gameObject.AddComponent<AudioSource>();
        Sound.clip = SoundOn;
        Sound.loop = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseUp()
    {
        gameObject.transform.position = pos;
    }

    void OnMouseDrag()
    {
        if (L_pause.IsPause == false)
        {
          //마우스 좌표를 받아온다.
          Vector3 mousePosition
          = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
          //마우스 좌표를 스크린 투 월드로 바꾸고 이 객체의 위치로 설정해 준다.
          this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);      

        }     
    }
    void trashEffOn()
    {
        Instantiate(trashEff, new Vector3(4.7f, -3, 0), Quaternion.identity); //고등어 회완성
        trash.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)

    {

        if (col.gameObject.tag == "Cat" || col.gameObject.tag == "Bird" || col.gameObject.tag == "Bird2"
            || col.gameObject.tag == "Penguin" || col.gameObject.tag == "Pen2")
        {
            fish.SetActive(false);
        }

        if (gameObject.tag == "Knife")
        {
          if (col.gameObject.tag == "Trash")
                 return;
            if (col.gameObject.tag == "Cat" || col.gameObject.tag == "Bird" || col.gameObject.tag == "Bird2"
                || col.gameObject.tag == "Penguin" || col.gameObject.tag == "Pen2")
            {
              return;
          }
          if (col.gameObject.tag == "DragEnd")
          {
              this.Sound.Play();
              Curfish.SetActive(false);
              Newfish.SetActive(true);
          }
        }
        if (gameObject.tag == "Trash")
        {
            if (col.gameObject.tag == "TrashBig")
                trashEffOn();
        }
    }
}
