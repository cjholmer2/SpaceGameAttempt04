using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour 
{
	private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float health = 100;
    public float damage = 10;
	public float speed = 1;
	public GameObject[] projectile;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;
    public int cash = 0;
    public float boostSpeed = 2;
    public float boostTime = 1;
    private bool boosting = false;
    private float boostTimer = 0;
    public GameObject deathParticles;

    public List<GameObject> weapons;
    GameObject lastWeapon;
    public GameObject currentWeapon;
    int weaponIndex = 0;

    Camera cam;

    // Use this for initialization
    void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if(GM.playerShip != null)
        {
            sr.sprite = GM.playerShip;
        }
        //GM.playerCash = cash;
        //Projectile.damage = damage;
        if(weapons.Count > 0)
        {
            currentWeapon = weapons[weaponIndex];
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float s = Input.GetAxis("Mouse ScrollWheel");

        if (h != 0 || v != 0)
        {
            Move(h, v);
        }
        else//this might not be triggered
        {
            rb.velocity = Vector2.zero;
        }
        transform.up = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y) - transform.position;

        if(s != 0)
        {
            weaponIndex = weaponIndex + (s > 0 ? 1 : -1);
            if(weaponIndex < 0)
            {
                weaponIndex += weapons.Count;
            }
            weaponIndex %= weapons.Count;
            currentWeapon = weapons[weaponIndex];
        }

        if (Statics.playerCanFire)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                Instantiate(weapons[weaponIndex], transform.position, transform.rotation, transform);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !boosting)
        {
            boosting = true;
            speed *= boostSpeed;
        }

        if(boosting)
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
        if (h != 0 && v != 0)
        {
            rb.velocity = rb.GetRelativeVector(new Vector2(h * speed, v * speed) / Mathf.Sqrt(2));
        }
        else
        {
            rb.velocity = rb.GetRelativeVector(new Vector2(h * speed, v * speed));
        }
    }

    public void ScrollWeapon()
    {
        //weaponIndex %= weapons.Count;
        //lastWeapon = currentWeapon;
        //lastWeapon.SetActive(false);
        //currentWeapon = weapons[weaponIndex];
        //currentWeapon.SetActive(true);
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
        sr.color = new Color(0,0,0,0);
        Instantiate(deathParticles, transform.position, transform.rotation, null);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            cash++;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            cash++;
        }
    }
}
