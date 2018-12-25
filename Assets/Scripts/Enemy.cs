using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject gm;
    private Rigidbody2D rb;
    public GameObject player;
    private bool canHit = true;
    private float timer = 0;
    public float health = 25;
    public float damage = 10;
    public float speed = 1;
    public float hitDelay = 1;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;

    public bool destroysSelf = true;
    public GameObject[] deathParticles;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM");
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(canHit == false)
        {
            timer += Time.deltaTime;
            if(timer > hitDelay)
            {
                canHit = true;
                timer = 0;
            }
        }
        if(!Statics.playerSafe)
        {
            transform.up = player.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && canHit == true)
        {
            canHit = false;
            other.gameObject.SendMessage("TakeDamage", damage);
            if(destroysSelf == true)
            {
                Die();
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine("DamageFlash");
        }
    }

    public void Die()
    {
        //gm.numberOfEnemies--;
        //gm.SendMessage("UpdateEnemies");
        Debug.Log("enemy dead");
        for (int i = 0; i < deathParticles.Length; i++)
        {
            Instantiate(deathParticles[i], transform.position, transform.rotation, null);
        }
        Destroy(gameObject);
    }
    
    public IEnumerator DamageFlash()
    {
        sr.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        sr.color = Color.white;
        yield return new WaitForSeconds(flashTime);
        sr.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        sr.color = Color.white;
    }
}
