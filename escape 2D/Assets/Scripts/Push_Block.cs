using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.name == "player")
        {
            //Vector3 v = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //GetComponent<Rigidbody2D>().AddForce(-v);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Rigidbody2D M = GetComponent<Rigidbody2D>();
            //M.mass = 1000;  // player는 보통과 같이 밀 수 있도록 질량을 1로 설정.
        }
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "obstacle")
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        */
        
        /*
        if (collision.gameObject.name == "player")
        {
             Vector3 v = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().AddForce(-v);
            //GetComponent<Rigidbody2D>().velocity=Vector3.zero;
            Rigidbody2D M = GetComponent<Rigidbody2D>();
            //M.mass = 1000;  // player는 보통과 같이 밀 수 있도록 질량을 1로 설정.
        }
        if (collision.gameObject.name != "player")
        {
            Rigidbody2D M = GetComponent<Rigidbody2D>();
            M.mass = 1000000; // 장애물들은 밀지 못하도록 질량을 최대로 설정.
            print("충돌\n");
        }
        */
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;        
    }

}
