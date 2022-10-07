using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour {

    public float tel_x;
    public float tel_y;
    public GameObject mycamera;
    public float cam_x;
    public float cam_y;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.transform.position = new Vector3(tel_x,tel_y,0);
            mycamera.transform.position = new Vector3(cam_x, cam_y, -10);
        }
    }
}
