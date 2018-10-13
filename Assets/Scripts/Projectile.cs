using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	private Rigidbody2D rb;
    public static float damage;
	public float speed = 1;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
        {
            other.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        else if(other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
	}
}
