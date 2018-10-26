using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    private GameObject gm;
    public GameObject target;
    private bool canHit = true;
    private float timer = 0;
    public float health = 25;
    public float damage = 10;
    public float speed = 1;
    public float hitDelay = 1;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;


    // Use this for initialization
    void Start ()
    {
        Projectile.damage = damage;
        target = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM");
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
        transform.up = target.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

    void OnDestroy()
    {
        GM.numberOfEnemies--;
        gm.SendMessage("UpdateEnemies");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && canHit == true)
        {
            canHit = false;
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }

    public void TakeDamage(float amount)
    {
        StartCoroutine("DamageFlash");
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// A flash effect for the controller's sprite renderer, typically called by TakeDamage().
    /// The controller's sprite renderer color will have changed back and forth between colors very quickly.
    /// </summary>
    /// <returns>I really wish I knew</returns>
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
