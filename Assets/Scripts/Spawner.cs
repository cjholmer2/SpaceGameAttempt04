using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawnObject;
    [Range(0, 100)]
    public int spawnChance;
    public float spawnRate;
    public int spawnsPerSpawn = 1;
    public bool infiniteSpawns = false;
    public int spawnCount;
    int count;
    public List<GameObject> spawnPoints;
    float timer = 0;

    void Start()
    {
        count = spawnCount;
    }

    void Update()
    {
        if(Statics.spawnersActive)
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                timer = 0;
                if ((Random.Range(0, 100) + 1 <= spawnChance))
                {
                    if (infiniteSpawns || count > 0)
                    {
                        for(int i = 0; i < spawnsPerSpawn; i++)
                        {
                            if (!infiniteSpawns)
                            {
                                count--;
                            }
                            int index = Random.Range(0, spawnPoints.Count);
                            Instantiate(spawnObject, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation, null);
                        }
                    }
                }
            }
        }
    }

    void ResetSpawnCount()
    {
        count = spawnCount;
    }

    void SetSpawnCount(int amount)
    {
        spawnCount = amount;
        ResetSpawnCount();
    }

    void SetInfiniteSpawns(bool infinite)
    {
        infiniteSpawns = infinite;
    }

    void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }
}
