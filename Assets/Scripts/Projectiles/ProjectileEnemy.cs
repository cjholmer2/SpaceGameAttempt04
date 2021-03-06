﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour 
{
	private Rigidbody2D rb;
    public float damage;
	public float speed = 1;
    public float lifetime = 3;

    // Use this for initialization
    void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") || other.CompareTag("Generator"))
        {
            other.gameObject.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if(!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
