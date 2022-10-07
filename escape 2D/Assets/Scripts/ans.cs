using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ans : MonoBehaviour
{
    public GameObject ANS;
    public Text text;
    public GameObject mycamera;
    
    
    public float tel_x;
    public float tel_y;
    
    public float cam_x;
    public float cam_y;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            ANS.SetActive(true);
            if (text.text == "80")
            {
                collision.transform.position = new Vector3(tel_x, tel_y, 0);
                mycamera.transform.position = new Vector3(cam_x, cam_y, -10);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            ANS.SetActive(false);
        }
    }
}
