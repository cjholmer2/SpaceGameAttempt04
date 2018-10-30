using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float health = 100;
    public float damage = 10;
	public float speed = 1;
	public GameObject[] projectile;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;
    public int cash = 1000;
    public float boostSpeed = 2;
    public float boostTime = 1;
    private bool boosting = false;
    private float boostTimer = 0;

    // Use this for initialization
    void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if(GM.playerShip != null)
        {
            sr.sprite = GM.playerShip;
        }
        GM.playerCash = cash;
        Projectile.damage = damage;
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
			Instantiate(projectile[0], transform.position, transform.rotation);
		}
        else if(Input.GetKeyDown(KeyCode.Alpha1) && projectile[1] != null)
        {
            Instantiate(projectile[1], transform.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && projectile[2] != null)
        {
            Instantiate(projectile[2], transform.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && projectile[3] != null)
        {
            Instantiate(projectile[3], transform.position, transform.rotation, gameObject.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && projectile[4] != null)
        {
            Instantiate(projectile[4], transform.position, transform.rotation, gameObject.transform);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && boosting == false)
        {
            boosting = true;
            speed *= boostSpeed;
        }

        if(boosting == true)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= boostTime)
            {
                boosting = false;
                speed /= boostSpeed;
                boostTimer = 0;
            }
        }
		
	}
	
    public void Move(float h, float v)
    {
        // stafe
        if(Input.GetKey(KeyCode.V))
        {
            rb.velocity = new Vector2(h * speed, v * speed);
        }
        // turn
        else if(Input.GetKey(KeyCode.C))
        {
            if (h != 0)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, (h > 0 ? Vector3.right : -Vector3.right));
            }
            else if (v != 0)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, (v > 0 ? Vector3.up : -Vector3.up));
            }
        }
        // turn and move forward
        else
        {
            if (h != 0)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, (h > 0 ? Vector3.right : -Vector3.right));
            }
            else if (v != 0)
            {
                transform.rotation = Quaternion.FromToRotation(Vector3.up, (v > 0 ? Vector3.up : -Vector3.up));
            }
            rb.velocity = transform.up * speed;
        }
		
    }

    public void SetSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
        GM.playerShip = newSprite;
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
