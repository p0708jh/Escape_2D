using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChargedPartcle : ChargedPartcle
{
    public float mass = 1;
    public Rigidbody2D rb;

    private void Start()
    {
        UpdateColor();

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.mass = mass;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0;
        //rb.useGravity = false;
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log(collision.gameObject.name);
            rb.velocity = Vector3.zero;
        }
    }

    */
}
