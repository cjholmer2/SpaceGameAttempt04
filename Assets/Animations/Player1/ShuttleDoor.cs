using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShuttleDoor : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;
    public string gotoScene;
    public bool open = false;

    void OpenDoor()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite;
        GetComponent<Collider2D>().isTrigger = true;
    }

    void CloseDoor()
    {
        GetComponent<SpriteRenderer>().sprite = closeSprite;
        GetComponent<Collider2D>().isTrigger = false;
    }

    void OnValidate()
    {
        if(open)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(gotoScene);
        }
    }
}
