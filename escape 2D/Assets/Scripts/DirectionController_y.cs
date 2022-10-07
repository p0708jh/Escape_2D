using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController_y : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moveObstacle;
    public int a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag );
        if (collision.gameObject.tag != "obstacle")
            moveObstacle.GetComponent<automove_y>().a = a;
        else if (collision.gameObject.tag== "obstacle")
        {
            if( collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
            moveObstacle.GetComponent<automove_y>().a = a;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "STAY");
        if (collision.gameObject.tag != "obstacle")
            moveObstacle.GetComponent<automove_y>().a = a;
        if (collision.gameObject.tag == "obstacle")
        {
            if (collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
                moveObstacle.GetComponent<automove_y>().a = a;
        }
    }
    
}
