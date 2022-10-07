using System.Collections;
using UnityEngine;

public class automove_xy : MonoBehaviour {

   

    public float speed = 3.0f; // 이동속도

    public bool xWallCheck = false;
    public bool yWallCheck = false;
    public int x = 1; // 이동방향
    public int y = 1; // 이동방향
    private Vector3 currentPos;
	void FixedUpdate () {

        //GetComponent<Rigidbody2D>().AddForce(;
        GetComponent<Rigidbody2D>().velocity = (new Vector3(x,y,0)*speed );
        currentPos = transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        StartCoroutine(Stay(collision));
    }

    public IEnumerator Stay(Collision2D collision)
    {
        yield return new WaitForSeconds(1f);




        if (transform.position==currentPos)
        {
            if (collision.gameObject.tag == "yWall")
            {
                x = 1 * (Mathf.Abs(x) / x);
                y = -1 * (Mathf.Abs(y) / y);
            }
            else if (collision.gameObject.tag == "xWall")
            {
                x = -1 * (Mathf.Abs(x) / x);
                y = 1 * (Mathf.Abs(y) / y);
            }
        }
        else
        Debug.Log(collision.gameObject.tag);
    }

}

