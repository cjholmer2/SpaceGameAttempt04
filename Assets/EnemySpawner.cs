using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float interval = 2;
    public bool spawnActive = true;
    private float timer = 0;
	
	// Update is called once per frame
	void Update ()
    {
        if(spawnActive == true)
        {
            timer += Time.deltaTime;
        }
		if(timer > interval)
        {
            Instantiate(enemy, transform.position, transform.rotation, null);
            timer = 0;
        }
	}
}
