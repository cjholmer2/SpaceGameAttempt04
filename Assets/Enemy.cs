using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject gm;
    public GameObject target;
    public float speed = 1;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("GM");
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.up = target.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
	}

    void OnDestroy()
    {
        GM.numberOfEnemies--;
        gm.SendMessage("UpdateEnemies");
    }
}
