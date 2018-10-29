using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParent : MonoBehaviour
{
    public GameObject[] projectiles;
    public float lifetime = 3;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, lifetime);
	}
}
