using System.Collections;
using UnityEngine;

public class automove_y : MonoBehaviour {

   

    public float speed = 3.0f; // 이동속도
    
    public bool yWallCheck = false;
    public int a = 1; // 이동방향

	void FixedUpdate () {

        //GetComponent<Rigidbody2D>().AddForce(;
        GetComponent<Rigidbody2D>().velocity = (new Vector3(0,1,0)*a*speed );

    }
    
}

