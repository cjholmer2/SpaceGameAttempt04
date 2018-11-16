using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private Rigidbody2D rb;
    //private SpriteRenderer sr;
    public float speed = 1;
    //public int cash = 1000;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Move(h, v);
        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) { }
    }

    public void Move(float h, float v)
    {
        if(h != 0 && v != 0)
        {
            rb.velocity = new Vector2(h * speed, v * speed) / Mathf.Sqrt(2);
        }
        else
        {
            rb.velocity = new Vector2(h * speed, v * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item") == true)
        {
            Destroy(other.gameObject);
        }
    }
}
