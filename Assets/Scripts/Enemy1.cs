using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
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

    public float visionRadius;
    public float attackRadius;
    public GameObject projectile;
    public float attackSpeed = 2f;
    bool attacking;
    Vector3 initialPosition, target;

    public GameObject[] deathParticles;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM");
        rb = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        target = initialPosition;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, visionRadius, 1 << LayerMask.NameToLayer("Default"));
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                target = player.transform.position;
            }
        }
        
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if (target != initialPosition && distance < attackRadius)
        {
            transform.up = player.transform.position - transform.position;
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
        else
        {
            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
            transform.up = player.transform.position - transform.position;
        }
        
        if (target == initialPosition && distance < 0.05f)
        {
            transform.position = initialPosition;
        }
        
        Debug.DrawLine(transform.position, target, Color.green);
        
    }
    
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

    IEnumerator Attack(float seconds)
    {
        attacking = true;
        if (target != initialPosition && projectile != null)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }

    /*
    void OnGUI()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Box(new Rect(pos.x - 20, Screen.height - pos.y + 60, 40, 24), hp + "/" + maxHp);
    }
    */

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && canHit == true)
        {
            canHit = false;
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(health);
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
        //GM.numberOfEnemies--;
        //gm.SendMessage("UpdateEnemies");
        Debug.Log("enemy dead");
        for(int i = 0; i < deathParticles.Length; i++)
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
