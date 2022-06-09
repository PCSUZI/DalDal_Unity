using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ChangeImg : MonoBehaviour
{
    SpriteRenderer spriteRenderer;


    private AudioSource Sound;
    public AudioClip Chop;

    public GameObject glass;

    public GameObject Cutfish;
    public GameObject Curfish;
    public GameObject Newfish;
    public GameObject Nextfish;

    public GameObject Yes;
    public GameObject No;

    public GameObject trashEff;

    private Vector3 pos;

    public Sprite CurrentSprite;
    public Sprite NextSprite;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (gameObject.tag == "Grass")
            spriteRenderer.color = new Color32(255, 255, 255, 0);
        if (gameObject.tag == "DDong")
            spriteRenderer.color = new Color32(255, 255, 255, 0);

        Sound = gameObject.AddComponent<AudioSource>();
        Sound.clip = Chop;
        Sound.loop = false;

        if (gameObject.tag == "Sauce")
            spriteRenderer.sprite = CurrentSprite;

        if (gameObject.tag == "Knife")
            spriteRenderer.sprite = CurrentSprite;

        pos = gameObject.transform.position;
    }
    void OnMouseDown()
    {
        if (gameObject.tag == "Sauce")
        {
            this.Sound.Play();
            spriteRenderer.sprite = NextSprite;
        }

        if (gameObject.tag == "DDong")
        {
            this.Sound.Play();
            Yes.SetActive(false);
            No.SetActive(true);
            spriteRenderer.color = new Color32(255, 255, 255, 255);
        }

        if (gameObject.tag == "Grass")
        {
            this.Sound.Play();
            spriteRenderer.color = new Color32(255, 255, 255, 255);
        }

    }
    void OnMouseUp()
    {
         gameObject.transform.position = pos;

        if (gameObject.tag == "Sauce")
            spriteRenderer.sprite = CurrentSprite;

        if (gameObject.tag == "DDong")
        {
            spriteRenderer.color = new Color32(255, 255, 255, 0);
            Yes.SetActive(true);
            No.SetActive(false);
        }

        if (gameObject.tag == "Grass")
            spriteRenderer.color = new Color32(255, 255, 255, 0);

    }

    void OnMouseDrag()
    {
        if (L_pause.IsPause == false)
        {
            if (gameObject.tag != "Scallops")
            {
                //마우스 좌표를 받아온다.
                Vector3 mousePosition
            = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
                //마우스 좌표를 스크린 투 월드로 바꾸고 이 객체의 위치로 설정해 준다.
                this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            }
        }
    }

    void Update()
    {

     
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.tag == "Knife")
        {
            if (col.gameObject.tag == "DragEnd")
            {
                spriteRenderer.sprite = NextSprite;
                if (Curfish.activeSelf)
                {
                    Curfish.SetActive(false);
                    Newfish.SetActive(true);
                }

                else if (Newfish.activeSelf)
                {
                    Cutfish.SetActive(false);
                    Nextfish.SetActive(true);
                }
            }
        }
        if (gameObject.tag == "Scallops")
        {
            if (col.gameObject.tag == "Sauce")
            {
                Curfish.SetActive(false);
                Newfish.SetActive(true);
            }
        }
        if (gameObject.tag == "Grassneed")
        {
            if (col.gameObject.tag == "Grass")
            {
                Curfish.SetActive(false);
                Newfish.SetActive(true);
            }
        }
        if (gameObject.tag == "DDong")
        {
            if (col.gameObject.tag == "TrashBig")
            {
                Instantiate(trashEff, new Vector3(4.7f, -3, 0), Quaternion.identity);
                Curfish.SetActive(false);
                Newfish.SetActive(true);
            }
        }
    }

}
