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

    void SetDamage(int dmg)
    {
        damage = dmg;
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Enemy") || other.CompareTag("Generator"))
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            other.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Obstacle"))
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
        else if(other.CompareTag("FriendlyProjectile"))
        {
            // do nothing
        }
        else if(other.CompareTag("PlayerPerson"))
        {
            // do nothing, ignore layer
        }
        else if (!other.CompareTag("Player"))
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
	}
}
