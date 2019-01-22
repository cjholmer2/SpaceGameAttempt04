using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public Vector2 offset;

    public void Interact()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = (Vector2)transform.position + offset;
        player.SendMessage("MoveVector", new Vector2(GetComponent<SpriteRenderer>().flipX ? -0.1f : 0.1f, 0));
    }
}
