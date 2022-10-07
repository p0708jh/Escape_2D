using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_push_block : MonoBehaviour {

    GameObject[] block;

    // Use this for initialization
    void Start () {
       block = GameObject.FindGameObjectsWithTag("stop_block");
        // 움직이는 물체들을 멈추기위해 배열로 컴포넌트를 불러옴
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.gameObject.tag == "push_block")
        {
            for(int i= 0;i<block.Length;i++)
            {
                automove_x stop =block[i].GetComponent<automove_x>();
                stop.enabled = false;
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "push_block")
        {
            for(int i= 0;i<block.Length;i++)
            {
                automove_x stop =block[i].GetComponent<automove_x>();
                stop.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "push_block")
        {
            for(int i= 0;i<block.Length;i++)
            {
                automove_x stop =block[i].GetComponent<automove_x>();
                stop.enabled = true;
            }
        }
    }
    

}
