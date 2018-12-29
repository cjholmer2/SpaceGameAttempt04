using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float maxHP = 100;
    public float hp = 100;
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

    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        cc.radius = (shieldActive ? shieldRadius : generatorRadius);
        sr = GetComponent<SpriteRenderer>();
        shieldsr = shield.GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        originalShieldColor = shieldsr.color;
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
            hp -= amount;
            if(hp <= 0)
            {
                Die();
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
}
