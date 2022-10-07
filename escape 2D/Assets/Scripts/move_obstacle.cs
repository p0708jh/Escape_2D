using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_obstacle : MonoBehaviour {

    public float speed = 5f;
    public float prevSpeed = 5f;

    public int movementType = 0;
    public bool orientToDirection = false;

    public bool horizontal_revers = false;
    public bool vertical_revers = false;
    public bool acceleration = false;
    public bool xWallCheck=false;
    public bool yWallCheck = false;

    public bool moveType=true;
    Rigidbody2D rb;

    Vector3 movementDirection;


    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");


        if (horizontal_revers == true && vertical_revers == true)
        {
            hInput = -Input.GetAxis("Horizontal");
            vInput = -Input.GetAxis("Vertical");
        }
        else if (horizontal_revers == true)
        { 
            hInput = -Input.GetAxis("Horizontal");
            vInput = Input.GetAxis("Vertical");
        }
        else if (vertical_revers == true)
        {
            hInput = Input.GetAxis("Horizontal");
            vInput = -Input.GetAxis("Vertical");
        }
        
        if (movementType == 1)
        {
            vInput = 0;
        }
        else if (movementType == 2)
        {
            hInput = 0;
        }

        movementDirection = new Vector3(hInput, vInput, 0).normalized;

        if(moveType ==true)
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        else
        rb.velocity = (movementDirection);

        // 만약 힘을주어 움직이는 방식인 가속도를 사용할때는 밑에 설정 켜놓기

        if (acceleration == true)
        {
            rb.AddForce(movementDirection * (speed * Time.deltaTime * rb.mass) * 100);
            if (hInput == 0 && vInput == 0)
                rb.velocity = Vector3.zero;
        }
        

        

        if (orientToDirection == true)
        {
            float radian = Mathf.Atan2(movementDirection.y, movementDirection.x);
            transform.rotation = Quaternion.Euler(0, 0, radian * Mathf.Rad2Deg);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
            moveType = false;

        if (collision.gameObject.tag == "xWall" || collision.gameObject.tag == "yWall"|| collision.gameObject.tag == "push_block")
        {
            if(collision.gameObject.tag == "xWall")
                xWallCheck = true;
            if (collision.gameObject.tag == "yWall")
                yWallCheck = true;
            if (collision.gameObject.tag == "push_block")
            {
                xWallCheck = true;
                yWallCheck = true;
            }
        }
        else if (collision.gameObject.tag == "obsacle")
        {
            xWallCheck = collision.gameObject.GetComponent<move_obstacle>().xWallCheck;
            yWallCheck = collision.gameObject.GetComponent<move_obstacle>().yWallCheck;
        }
        else
        {
            xWallCheck = false;
            yWallCheck = false;
        }

        if(collision.gameObject.tag=="wall")
            moveType = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
            moveType = false;





        if (collision.gameObject.tag == "xWall" || collision.gameObject.tag == "yWall")
        {
            if (collision.gameObject.tag == "xWall")
                xWallCheck = true;
            if (collision.gameObject.tag == "yWall")
                yWallCheck = true;
        }
        else if (collision.gameObject.CompareTag("obstacle") && (collision.gameObject.GetComponent<move_obstacle>().xWallCheck || collision.gameObject.GetComponent<move_obstacle>().yWallCheck))
        {
            xWallCheck = collision.gameObject.GetComponent<move_obstacle>().xWallCheck;
            yWallCheck = collision.gameObject.GetComponent<move_obstacle>().yWallCheck;
        }
        else if (collision.gameObject.tag == "stop_block" || collision.gameObject.tag == "obstacle")
            moveType = false;
        else if (collision.gameObject.tag == "wall")
            moveType = false;
        else
        {
            moveType = true;
            xWallCheck = false;
            yWallCheck = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = new Vector3(0,0,0);
        xWallCheck = false;
        yWallCheck = false;
        moveType = true;
    }

}

