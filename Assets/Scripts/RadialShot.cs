using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShot : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 10;
    public float lifetime = 5;
    public float shots = 6;
    int count = 0;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(count < shots && count % 2 == 0)
        {
            for (int i = 0; i < 36; i++)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                transform.Rotate(0, 0, -speed);
            }
        }
        if(count < shots)
        {
            count++;
        }
	}
}
