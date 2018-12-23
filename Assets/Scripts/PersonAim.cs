using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAim : MonoBehaviour
{
    Camera cam;
    public GameObject projectile;
    public bool melee = false;
    public GameObject meleeTemp;
    Animator anim;
    public float attackTime = 1;
    bool attack1 = false;
    bool attack2 = false;
    bool attack3 = false;
    float timer = 0;
    public float damage = 15;
    public GameObject particles;
    Collider2D col;
    

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("CameraPerson").GetComponent<Camera>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();

    }

    void Update ()
    {
        transform.up = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y) - transform.position;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            if (melee == true && meleeTemp == null)
            {
                meleeTemp = Instantiate(projectile, transform.position, transform.rotation, transform);
            }
            else if (melee == false)
            {
                Instantiate(projectile, transform.position, transform.rotation, null);
            }
        }
        /*
        timer += Time.deltaTime;

        if (timer > attackTime)
        {
            attack1 = false;
            attack2 = false;
            attack3 = false;
            anim.ResetTrigger("Attack1");
            anim.ResetTrigger("Attack2");
            anim.ResetTrigger("Attack3");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1") && attack3 == false)
        {
            timer = 0;
            if (attack1 == false)
            {
                anim.SetTrigger("Attack1");
                attack1 = true;
            }
            else if (attack1 == true && attack2 == false)
            {
                anim.SetTrigger("Attack2");
                attack2 = true;
            }
            else if (attack2 == true)
            {
                anim.SetTrigger("Attack3");
                attack3 = true;
            }
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(particles, other.transform.position, other.transform.rotation, null);
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }
}
