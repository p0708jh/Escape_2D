using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Overlap : MonoBehaviour
{


    //public joystick_value value;
    public float speed = 5f;

    public int movementType = 0;
    public bool orientToDirection = true;
    public bool acceleration = false;

    Vector3 movementDirection;

    //[HideInInspector]
    public int point = 0;

    // Use this for initialization
    void Start()
    {
      
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

       

        // 이놈때문에 파고듬 rigidbody의 v를 이용한 움직임구현 , fixed Update로 물리구현 
        // 프레임을 40으로 맞춰놓고 vsync를 껐음 따라서 fixed Update 필요없음 
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World); 



        /*
        // 만약 힘을주어 움직이는 방식인 가속도를 사용할때는 밑에 설정 켜놓기

        if (acceleration == true)
        {
            rb.AddForce(movementDirection * (speed * Time.deltaTime * rb.mass) * 100);
            if (hInput == 0 && vInput == 0)
                rb.velocity = Vector3.zero;
        }
        */
        if (orientToDirection == true)
        {
            float radian = Mathf.Atan2(movementDirection.y, movementDirection.x);
            transform.rotation = Quaternion.Euler(0, 0, radian * Mathf.Rad2Deg);
        }
        
    }
}
