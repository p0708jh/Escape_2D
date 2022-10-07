using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public Sprite CurrentSprite;
    private SpriteRenderer spriteRenderer;
    public Sprite NextSprite;
    public GameObject leftLight;
    public GameObject rightLight;

    bool lightUp=false;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite; //checkpoint 이미지변경을위함

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Change(collision,2);

            //Collider2D controller = GetComponent<Collider2D>();
            //controller.enabled = false; // 점수 중복차단 콜라이더 off
        }
    }

    public void Change(Collider2D player ,int x)
    {
        if (x == 2)
        {
            if (lightUp == false)
            {
                spriteRenderer.sprite = NextSprite;
                lightUp = true;
                leftLight.GetComponent<light>().Change(player,x - 1);
                rightLight.GetComponent<light>().Change(player, x - 1);
                player.gameObject.GetComponent<move_player>().point++;
            }
            else
            {
                spriteRenderer.sprite = CurrentSprite;
                lightUp = false;
                leftLight.GetComponent<light>().Change(player, x - 1);
                rightLight.GetComponent<light>().Change(player, x - 1);
                player.gameObject.GetComponent<move_player>().point--;
            }
        }
        else if (x == 1)
        {
            if (lightUp == false)
            {
                spriteRenderer.sprite = NextSprite;
                lightUp = true;
                player.gameObject.GetComponent<move_player>().point++;
            }
            else
            {
                spriteRenderer.sprite = CurrentSprite;
                lightUp = false;
                player.gameObject.GetComponent<move_player>().point--;
            }
        }
    }
}
