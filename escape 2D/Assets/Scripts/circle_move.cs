using System.Collections;
using UnityEngine;

public class circle_move : MonoBehaviour
{



    public float speed = 3.0f; // 이동속도

    public bool yWallCheck = false;
    public int x = 1; // 이동방향
    public int y = 1; // 이동방향
    private Vector3 currentPos;
    void FixedUpdate()
    {

        //GetComponent<Rigidbody2D>().AddForce(;
        GetComponent<Rigidbody2D>().velocity = (new Vector3(x, y, 0) * speed);
        currentPos = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "upPlayerCollider")
            {
                y = -1;
            }
            else if (collision.gameObject.tag == "downPlayerCollider")
            {
                y = 1;
            }
            else if (collision.gameObject.tag == "rightPlayerCollider")
            {
                x = -1;
            }
            else if (collision.gameObject.tag == "leftPlayerCollider")
            {
                x = 1;
           }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {

        StartCoroutine(Stay(collision));
    }

    public IEnumerator Stay(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);




        if (transform.position == currentPos)
        {
            if (collision.gameObject.tag == "upPlayerCollider")
            {
                y = -1;
            }
            else if (collision.gameObject.tag == "downPlayerCollider")
            {
                y = 1;
            }
            else if (collision.gameObject.tag == "rightPlayerCollider")
            {
                x= -1;
            }
            else if (collision.gameObject.tag == "leftPlayerCollider")
            {
                x = 1;
            }
        }
     
    }
    
}

