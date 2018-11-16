using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	private Rigidbody2D rb;
    public static float damage;
	public float speed = 1;
    public float lifetime = 3;
    public GameObject particles;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, lifetime);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            other.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        else if(other.tag == "Obstacle")
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
        else if(other.tag == "FriendlyProjectile")
        {
            // do nothing
        }
        else if (other.tag != "Player")
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
	}
}
