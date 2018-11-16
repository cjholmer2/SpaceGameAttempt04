using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject/*change to Item later?*/> items;
    [Range(0, 100)]
    public float spawnChance = 10;

    void Start()
    {
        if(items.Count > 0)
        {
            if(Random.Range(0.0f, 100.0f) < spawnChance)
            {
                Instantiate(items[Random.Range(0, items.Count)], transform);
            }
        }
    }
}
