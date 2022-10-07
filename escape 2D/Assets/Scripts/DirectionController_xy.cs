using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController_xy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject moveObstacle;
    public int x;
    public int y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        x = Mathf.Abs(moveObstacle.GetComponent<automove_xy>().x) / moveObstacle.GetComponent<automove_xy>().x;
        y= 1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().y) / moveObstacle.GetComponent<automove_xy>().y;
        if (transform.name == "upCollider" || transform.name == "downCollider")
        {
            
            if (collision.gameObject.tag != "obstacle")
            {
                moveObstacle.GetComponent<automove_xy>().x = 1*x;
                moveObstacle.GetComponent<automove_xy>().y = -1 * y;
            }
            else if (collision.gameObject.tag == "obstacle")
            {
                if (collision.gameObject.GetComponent<move_obstacle>().xWallCheck == true || collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
                {
                    moveObstacle.GetComponent<automove_xy>().yWallCheck = true;
                    moveObstacle.GetComponent<automove_xy>().x = 1 * x;
                    moveObstacle.GetComponent<automove_xy>().y = -1 * y;
                }
            }
        }
        else if (transform.name == "rightCollider" || transform.name == "leftCollider")
        {
            if (collision.gameObject.tag != "obstacle")
            {
                moveObstacle.GetComponent<automove_xy>().x = -1*x;
                moveObstacle.GetComponent<automove_xy>().y = 1 * y;
            }
            else if (collision.gameObject.tag == "obstacle")
            {
                if (collision.gameObject.GetComponent<move_obstacle>().xWallCheck == true || collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
                {
                    moveObstacle.GetComponent<automove_xy>().xWallCheck = true;
                    moveObstacle.GetComponent<automove_xy>().x = -1 * x;
                    moveObstacle.GetComponent<automove_xy>().y = 1 * y;
                }
            }
        }
        
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        x = Mathf.Abs(moveObstacle.GetComponent<automove_xy>().x) / moveObstacle.GetComponent<automove_xy>().x;
        y = 1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().y) / moveObstacle.GetComponent<automove_xy>().y;

        if (transform.name == "upCollider" || transform.name == "downCollider")
        {

            if (collision.gameObject.tag == "stop_block")
            {
                moveObstacle.GetComponent<automove_xy>().x = 1 * x;
                moveObstacle.GetComponent<automove_xy>().y = -1 * y;
            }

            if (collision.gameObject.tag != "obstacle")
                moveObstacle.GetComponent<automove_xy>().y = y;
            else if (collision.gameObject.tag == "obstacle")
            {
                if (collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
                    moveObstacle.GetComponent<automove_xy>().y = y;
            }

        }
        else if (transform.name == "rightCollider" || transform.name == "leftCollider")
        {
            if (collision.gameObject.tag == "stop_block")
            {
                moveObstacle.GetComponent<automove_xy>().x = -1 * x;
                moveObstacle.GetComponent<automove_xy>().y = 1 * y;
            }

            if (collision.gameObject.tag != "obstacle")
                moveObstacle.GetComponent<automove_xy>().x = x;
            else if (collision.gameObject.tag == "obstacle")
            {
                if (collision.gameObject.GetComponent<move_obstacle>().xWallCheck == true)
                    moveObstacle.GetComponent<automove_xy>().x = x;
            }

        }

        //Debug.Log(collision.gameObject.tag);
    }
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (transform.name == "upCollider" || transform.name == "downCollider")
        {
            if (collision.gameObject.tag != "obstacle")
            {
                moveObstacle.GetComponent<automove_xy>().x = 1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().x) / moveObstacle.GetComponent<automove_xy>().x;
                moveObstacle.GetComponent<automove_xy>().y = -1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().y) / moveObstacle.GetComponent<automove_xy>().y;
            }
            else if (collision.gameObject.tag == "obstacle")
            {
                if (collision.gameObject.GetComponent<move_obstacle>().xWallCheck == true || collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
                {
                    moveObstacle.GetComponent<automove_xy>().x = 1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().x) / moveObstacle.GetComponent<automove_xy>().x;
                    moveObstacle.GetComponent<automove_xy>().y = -1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().y) / moveObstacle.GetComponent<automove_xy>().y;
                }
            }
        }
        else if (transform.name == "rightCollider" || transform.name == "leftCollider")
        {
            if (collision.gameObject.tag != "obstacle")
            {
                moveObstacle.GetComponent<automove_xy>().x = -1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().x) / moveObstacle.GetComponent<automove_xy>().x;
                moveObstacle.GetComponent<automove_xy>().y = 1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().y) / moveObstacle.GetComponent<automove_xy>().y;
            }
            else if (collision.gameObject.tag == "obstacle")
            {
                if (collision.gameObject.GetComponent<move_obstacle>().xWallCheck == true || collision.gameObject.GetComponent<move_obstacle>().yWallCheck == true)
                {
                    moveObstacle.GetComponent<automove_xy>().x = -1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().x) / moveObstacle.GetComponent<automove_xy>().x;
                    moveObstacle.GetComponent<automove_xy>().y = 1 * Mathf.Abs(moveObstacle.GetComponent<automove_xy>().y) / moveObstacle.GetComponent<automove_xy>().y;
                }
            }
        }
    }
    */
}
