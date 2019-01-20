using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public float spawnWait = 1;
    public float speed = 3;
    public float force = 1;
    bool canLoot = false;
    float timer = 0;
    Collider2D col;
    Rigidbody2D rb;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("PlayerPerson");
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        rb.AddForce(new Vector2(Random.Range(-1 * force, 1 * force), Random.Range(-1 * force, 1 * force)));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnWait && canLoot == false)
        {
            col.isTrigger = true;
            canLoot = true;
        }
        if(canLoot == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, timer);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Box"))
        {
            col.isTrigger = false;
        }
    }
}
    
