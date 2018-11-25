using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite openSprite;
    public List<GameObject> loot;
    bool open = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(open == false)
            {
                open = true;
                sr.sprite = openSprite;
                for(int i = 0; i < loot.Count; i++)
                {
                    Instantiate(loot[i], transform.position, transform.rotation, transform);
                }
            }
        }
    }
}
