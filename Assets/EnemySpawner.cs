using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies = 5;
    public float interval = 2;
    public bool spawnActive = true;
    private float timer = 0;
    private GameObject gm;
   
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM");
        GM.numberOfEnemies = numberOfEnemies;
        gm.SendMessage("UpdateEnemies");
    }

    // Update is called once per frame
    void Update ()
    {
        if(spawnActive == true && numberOfEnemies > 0)
        {
            timer += Time.deltaTime;
        }
		if(timer > interval)
        {
            Instantiate(enemy, transform.position, transform.rotation, null);
            numberOfEnemies--;
            timer = 0;
        }
	}

    public void SetActivetate(bool active)
    {
        spawnActive = active;
    }
}
