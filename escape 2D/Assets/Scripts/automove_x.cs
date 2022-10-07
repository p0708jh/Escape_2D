using System.Collections;
using UnityEngine;

public class automove_x : MonoBehaviour {

   

    public float speed = 3.0f; // 이동속도

    public int a = 1; // 이동방향

	void FixedUpdate () {

        //GetComponent<Rigidbody2D>().AddForce(;
        GetComponent<Rigidbody2D>().velocity = (new Vector3(1,0,0)*a*speed );


    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "yWall")
        {
     
        }
        else if (collision.gameObject.tag == "obstacle"&&collision.gameObject.GetComponent<move_obstacle>().xWallCheck == true)
        {
                a *= -1;
        }
        else if(collision.gameObject.tag != "obstacle")
        {
            a *= -1;
            Debug.Log("충돌"+ collision.gameObject.name);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector3 x = transform.position;

        if (collision.gameObject.tag == "yWall")
        {

        }
        else if (collision.gameObject.tag != "obstacle")
            StartCoroutine(Wait(transform.position,true));
        else if (collision.gameObject.tag == "obstacle" && x.x==transform.position.x)
            StartCoroutine(WaitObstacle(transform.position, collision.gameObject.GetComponent<move_obstacle>().xWallCheck));

        //Debug.Log("Stay" + collision.gameObject.name);
    }

    IEnumerator Wait(Vector3 x,bool wallCheck=false)
    {

        yield return new WaitForSeconds(0.04f);
        if (x.x == transform.position.x && wallCheck == true)
        {
            a *= -1;
        }
    }
    IEnumerator WaitObstacle(Vector3 x, bool wallCheck = false)
    {
        yield return new WaitForSeconds(0.02f);

        if (Mathf.Round(x.x * 10) / 10 == Mathf.Round(transform.position.x * 10) / 10 && wallCheck == true)
        {
            a *= -1;
        }
    }
    */

    /*
    Vector3 v = pos;

    v.x += delta * Mathf.Sin(Time.time * speed);

    // Mathf.sin() 함수는 f(라디안의 각도) 를 입력받아 -1과 1사이의 float값을 반환하는 함수

    transform.position = v;
    */
}

