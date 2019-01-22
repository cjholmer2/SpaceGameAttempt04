using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [HideInInspector] public Vector2 NORTH = new Vector2(0, 01f);
    [HideInInspector] public Vector2 SOUTH = new Vector2(0, -01f);
    [HideInInspector] public Vector2 EAST = new Vector2(01f, 0);
    [HideInInspector] public Vector2 WEST = new Vector2(-01f, 0);
    [HideInInspector] public Vector2 currentDirection;

    [HideInInspector] public float north = 0;
    [HideInInspector] public float south = 180;
    [HideInInspector] public float east = 270;
    [HideInInspector] public float west = 90;
    [HideInInspector] public float currentDir;

    [HideInInspector] public float x;
    [HideInInspector] public float y;

    [HideInInspector] public Vector2 deltaForce;
    [HideInInspector] public Vector2 lastDirection;

    [HideInInspector] public bool moveable;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isAttacking;

    [HideInInspector] public Animator anim;
    [HideInInspector] public Collider2D bc;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer sr;

    [HideInInspector] public float timer;               // To measure time
    [HideInInspector] public float maxTimer = 60.0f;    // Maximum time for timer


    public int hp = 1;
    public int damage = 1;
    public float speed = 2f;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;
    public float killDelay = 0.2f;

    // Use this for initialization
    public virtual void Start ()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        timer = 0.0f;
    }

    // Update is called once per frame
    public virtual void Update ()
    {
        // Timer counts until a max time is reached
        if (timer <= maxTimer)
        {
            timer += Time.deltaTime;
        }
    }


    /// <summary>
    /// Sends info to this object's animator to determine which animations will be played.
    /// </summary>
    public void SendAnimInfo()
    {
        anim.SetFloat("xSpeed", rb.velocity.x);
        anim.SetFloat("ySpeed", rb.velocity.y);
        anim.SetFloat("xLast", lastDirection.x);
        anim.SetFloat("yLast", lastDirection.y);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isMoving", isMoving);
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

    /// <summary>
    /// Deals damage to the controlling character, typically called by an offending character.
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        StartCoroutine("DamageFlash");
        UpdateHP(damage);
        if (hp <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Updates the health of the controlling character.
    /// </summary>
    /// <param name="damage">The amount of health taken away (added if negative value)</param>
    public virtual void UpdateHP(int damage)
    {
        hp--;
    }

    /// <summary>
    /// Kills the controlling character.
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject, killDelay);
    }
}
