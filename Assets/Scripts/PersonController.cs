using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float speed = 1;
    public int cash = 1000;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if (h != 0 ^ v != 0)
        {
            Move(h, v);
        }
        else if (h != 0 && v != 0)
        {
            //do nothing (prevents diagonal movement, moving the player in the current direction)
        }
        else//this might not be triggered
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
        }
    }

    public void Move(float h, float v)
    {
        if (h != 0)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, (h > 0 ? Vector3.right : -Vector3.right));
        }
        else if (v != 0)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, (v > 0 ? Vector3.up : -Vector3.up));
        }
        rb.velocity = transform.up * speed;
    }
}
