using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEnemy : MonoBehaviour
{
    private SpriteRenderer sr;
    public float health = 25;
    public float flashTime = 0.1f;
    public Color flashColor = Color.red;
    private Color originalColor;

    // Use this for initialization
    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
	

    public void TakeDamage(float amount)
    {
       // health -= amount;
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
        Destroy(gameObject);
    }

    public IEnumerator DamageFlash()
    {
        sr.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        sr.color = originalColor;
        yield return new WaitForSeconds(flashTime);
        sr.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        sr.color = originalColor;
    }
}
