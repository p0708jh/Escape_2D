using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{
    public float speedPercent=0;
    public Sprite N;
    public float minusSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.GetChild(1).GetComponent<ChargedPartcle>().charge = -minusSize;
            collision.gameObject.GetComponent<move_player>().speed = collision.gameObject.GetComponent<move_player>().prevSpeed + collision.gameObject.GetComponent<move_player>().prevSpeed * speedPercent*0.01f;
            collision.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = N;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            collision.gameObject.GetComponent<move_obstacle>().speed = collision.gameObject.GetComponent<move_obstacle>().prevSpeed-collision.gameObject.GetComponent<move_obstacle>().prevSpeed * speedPercent * 0.01f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.GetChild(1).GetComponent<ChargedPartcle>().charge = -minusSize;
            //collision.gameObject.GetComponent<move_player>().speed = collision.gameObject.GetComponent<move_player>().prevSpeed + collision.gameObject.GetComponent<move_player>().prevSpeed * speedPercent * 0.01f;
            collision.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = N;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {

            collision.gameObject.GetComponent<move_player>().speed = collision.gameObject.GetComponent<move_player>().prevSpeed;
        }
        if (collision.gameObject.tag == "obstacle")
        {
            collision.gameObject.GetComponent<move_obstacle>().speed = collision.gameObject.GetComponent<move_obstacle>().prevSpeed;
        }
    }


    public IEnumerator SpeedController()
    {
        yield return null;
    }
}
