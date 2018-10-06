using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextShip : MonoBehaviour 
{
	public GameObject player;
	public Sprite[] shipSprites;
	private int index = 0;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Next();
        }
    }

    public void Next()
	{
		index++;
        index %= shipSprites.Length;
		player.GetComponent<SpriteRenderer>().sprite = shipSprites[index];
	}
}
