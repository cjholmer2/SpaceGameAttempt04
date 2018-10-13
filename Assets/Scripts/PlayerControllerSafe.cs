using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSafe : MonoBehaviour 
{
	private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float health = 100;
    public float damage = 10;
	public float speed = 1;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;

    // Use this for initialization
    void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
		
        if (h != 0 ^ v != 0)
        {
			Move(h, v);
        }
        else if (h != 0 && v != 0)
        {
            //do nothing (prevents diagonal movement, moving the player in the current direction)
        }
        else//this might not be triggered
        {
            rb.velocity = Vector2.zero;
        }
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
		{
		}
		
	}
	
    /// <summary>
    /// Moves the object depending on the passed in values.
    /// </summary>
    /// <param name="h">Value of horizontal input</param>
    /// <param name="v">Value of vertical</param>
    public void Move(float h, float v)
    {
		if(h != 0)
		{
			transform.rotation = Quaternion.FromToRotation(Vector3.up, (h > 0 ? Vector3.right : -Vector3.right));
		}
		else if(v != 0)
		{
			transform.rotation = Quaternion.FromToRotation(Vector3.up, (v > 0 ? Vector3.up : -Vector3.up));
		}
		
		rb.velocity = transform.up * speed;
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }

    public void TakeDamage(float amount)
    {
        StartCoroutine("DamageFlash");
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("nothin");
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
