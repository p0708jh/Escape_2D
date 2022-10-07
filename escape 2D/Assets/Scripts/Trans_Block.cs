using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class Trans_Block : MonoBehaviour {

    public Sprite CurrentSprite;
    private SpriteRenderer spriteRenderer;
    public Sprite NextSprite;

    // Use this for initialization
    void Start () {

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite; //checkpoint 이미지변경을위함


    }

    // Update is called once per frame
    void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.GetChild(1).GetComponent<ChargedPartcle>().charge = 0; // 전하의양
            collision.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null; // player 내부 구슬
        }
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            spriteRenderer.sprite = NextSprite;
            Collider2D trigger = GetComponent<Collider2D>();
            trigger.isTrigger = false;

        }
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != "Stage30")
        {
            if (transform.GetComponent<SpriteRenderer>().sprite == NextSprite)
            {
                if (transform.GetComponentInParent<spark>() != null)
                    transform.GetComponentInParent<spark>().enabled = false;
            }
        }
    }
    
}
