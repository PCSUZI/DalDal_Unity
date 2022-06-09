using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarSpriteChage : MonoBehaviour
{
    public Sprite CurSprite;
    public Sprite NextSprite;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (L_pause.IsPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                spriteRenderer.sprite = NextSprite;

            if (Input.GetKeyUp(KeyCode.Space))
                spriteRenderer.sprite = CurSprite;
        }
    }
}
