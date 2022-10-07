using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class move_player : MonoBehaviour
{
    Rigidbody2D rb;

    //public joystick_value value;
    public float speed = 5f;
    public float prevSpeed = 5f;
    public int movementType = 0;
    public bool orientToDirection = true;
    public bool acceleration = false;

    Vector3 movementDirection;

    public bool moveType = true;

    //[HideInInspector]
    public int point = 0;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    /*void Update()
    {
        //Debug.Log("update" + Time.deltaTime);
    }
    */

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(value.joyTouch);

        //Debug.Log("fixedupdate" + 40*Time.deltaTime);

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if (movementType == 1)
        {
            vInput = 0;
        }
        else if (movementType == 2)
        {
            hInput = 0;
        }
        
        movementDirection = new Vector3(hInput, vInput, 0).normalized;

        // 힘을가해 움직이는 방식
        //rb.velocity=(movementDirection * speed); 



        // 이놈때문에 파고듬 rigidbody의 v를 이용한 움직임구현 , fixed Update로 물리구현 
        // 프레임을 40으로 맞춰놓고 vsync를 껐음 따라서 fixed Update 필요없음 

        //위치를 통해 움직이는 방식
        if (moveType == true)
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
            if (hInput == 0 && vInput == 0)
                rb.velocity = Vector3.zero;
            float radian = Mathf.Atan2(movementDirection.y, movementDirection.x);
            transform.rotation = Quaternion.Euler(0, 0, radian * Mathf.Rad2Deg);
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScreenCapture.CaptureScreenshot( SceneManager.GetActiveScene().name+ "MapScreenShot" + ".png");
            Debug.Log("스크린샷저장");
        }
#endif
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "xWall" || collision.gameObject.tag == "yWall")
            moveType = false;
        */
        if (collision.gameObject.tag == "push_block")
        {
            Vector3 po = collision.transform.position;

            //transform.Translate(-movementDirection * speed * Time.deltaTime, Space.World);

        }
        //Debug.Log("enter" + collision.gameObject.tag);
    }
    /*
    private void OnCollsionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall"|| collision.gameObject.tag == "xWall"|| collision.gameObject.tag == "yWall")
            moveType = false;

        Debug.Log("stay" + collision.gameObject.tag);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = new Vector3(0, 0, 0);
        moveType = true;
    }
    */
}

