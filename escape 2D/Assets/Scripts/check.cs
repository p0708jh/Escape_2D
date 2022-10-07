using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class check : MonoBehaviour {
    public Sprite CurrentSprite;
    private SpriteRenderer spriteRenderer;
    public Sprite NextSprite;


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite; //checkpoint 이미지변경을위함
           
        

    }
    

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            spriteRenderer.sprite = NextSprite;
            //move_player po = player.GetComponent<move_player>();
            collision.gameObject.GetComponent<move_player>().point++; 
            //checkpoint도달시 플레이어의 점수를 올림
            Collider2D controller = GetComponent<Collider2D>(); 
            controller.enabled = false; // 점수 중복차단 콜라이더 off
        }
        if (collision.gameObject.tag == "push_block")
        {
            spriteRenderer.sprite = NextSprite;
            GameObject.Find("player").GetComponent<move_player>().point++;
            Collider2D controller = GetComponent<Collider2D>();
            controller.enabled = false;
        }
    }
}
