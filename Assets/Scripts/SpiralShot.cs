using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShot : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 10;
    public float shotInterval = 0.1f;
    public float lifetime = 5;
    public float distance = 3;
    float timer = 0.1f;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= shotInterval)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            transform.Rotate(0, 0, -speed);
            timer = 0;
        }
	}
}
