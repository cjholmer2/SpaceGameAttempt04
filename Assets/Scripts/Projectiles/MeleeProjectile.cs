using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeProjectile : MonoBehaviour
{
    public float damage = 15;
    public GameObject particles;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(particles, transform.position, transform.rotation, null);
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }
}
