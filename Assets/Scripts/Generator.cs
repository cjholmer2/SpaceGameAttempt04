using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public float generatorRadius;
    public float maxShield = 100;
    public float shieldHealth = 100;
    public float shieldRadius;

    CircleCollider2D cc;
    SpriteRenderer sr;

    public GameObject shield;
    public bool shieldActive = true;
    SpriteRenderer shieldsr;

    public float flashTime = 0.1f;
    public Color32 flashColor = Color.red;
    Color32 originalColor;
    Color32 originalShieldColor;

    public GameObject deathParticles;

    Camera cam;

    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        cc.radius = (shieldActive ? shieldRadius : generatorRadius);
        sr = GetComponent<SpriteRenderer>();
        shieldsr = shield.GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        originalShieldColor = shieldsr.color;
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
    }

    void TakeDamage(float amount)
    {
        if(shieldHealth > 0)
        {
            shieldHealth -= amount;
            if(shieldHealth <= 0)
            {
                shield.SetActive(false);
                shieldActive = false;
                cc.radius = generatorRadius;
            }
            else
            {
                StartCoroutine(DamageFlash(shieldsr));
            }
        }
        else
        {
            health -= amount;
            if(health <= 0)
            {
                Die();
                health = 0;
            }
            else
            {
                StartCoroutine(DamageFlash(sr));
            }
        }
    }

    void RestoreShield(float amount)
    {
        if (!shieldActive)
        {
            shield.SetActive(true);
            shieldHealth = amount;
            shieldActive = true;
            cc.radius = shieldRadius;
        }
        else if ((shieldHealth + amount) > maxShield)
        {
            shieldHealth = maxShield;
        }
        else
        {
            shieldHealth += amount;
        }
    }
    
    public void Die()
    {
        Debug.Log("enemy dead");
        Instantiate(deathParticles, transform.position, transform.rotation, null);
        //Destroy(gameObject);
        sr.color = new Color(0, 0, 0, 0);
    }

    public IEnumerator DamageFlash(SpriteRenderer renderer)
    {
        renderer.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        renderer.color = (shieldActive ? originalShieldColor : originalColor);
        yield return new WaitForSeconds(flashTime);
        renderer.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        renderer.color = (shieldActive ? originalShieldColor : originalColor);
    }
    
    void OnGUI()
    {
        Vector2 pos = cam.WorldToScreenPoint(transform.position);
        
        if(shieldHealth > 0)
        {
            GUI.DrawTexture(new Rect(pos.x - shieldHealth / 2, Screen.height - pos.y + 60, shieldHealth, 12), Styles.boxTexture, ScaleMode.StretchToFill, true, 0, Styles.shieldColor, 0, 0);
        }
        if(health > 0)
        {
            GUI.DrawTexture(new Rect((pos.x - health / 2) + 2, Screen.height - pos.y + 62, health - 4, 8), Styles.boxTexture, ScaleMode.StretchToFill, true, 0, Styles.healthColor, 0, 0);
        }
    }
}
