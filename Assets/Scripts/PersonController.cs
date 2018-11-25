using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private Rigidbody2D rb;
    //private SpriteRenderer sr;
    public float speed = 1;
    public int cash = 0;
    //Animator anim;
    //public float attackTime = 1;
    //bool attack1 = false;
    //bool attack2 = false;
    //bool attack3 = false;
    //float timer = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sr = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Move(h, v);


        //timer += Time.deltaTime;

        //if(timer > attackTime)
        //{
        //    attack1 = false;
        //    attack2 = false;
        //    attack3 = false;
        //    anim.ResetTrigger("Attack1");
        //    anim.ResetTrigger("Attack2");
        //    anim.ResetTrigger("Attack3");
        //}

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1") && attack3 == false) 
        //{
        //    timer = 0;
        //    if(attack1 == false)
        //    {
        //        anim.SetTrigger("Attack1");
        //        attack1 = true;
        //    }
        //    else if(attack1 == true && attack2 == false)
        //    {
        //        anim.SetTrigger("Attack2");
        //        attack2 = true;
        //    }
        //    else if(attack2 == true)
        //    {
        //        anim.SetTrigger("Attack3");
        //        attack3 = true;
        //    }
        //}
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
            cash++;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Item") == true)
        {
            Destroy(other.gameObject);
            cash++;
        }
    }
}
