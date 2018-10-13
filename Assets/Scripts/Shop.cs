using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopCanvas;
    public GameObject indicator;
    private bool inCollider = false;
    private bool shopOpen = false;

    void Start()
    {
        shopCanvas.SetActive(false);
        indicator.SetActive(false);
    }
    void Update()
    {
        if(inCollider == true && shopOpen == false)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1"))
            {
                OpenShop();
            }
        }
    }

    public void OpenShop()
    {
        indicator.SetActive(false);
        shopCanvas.SetActive(true);
        shopOpen = true;
    }

    public void ExitShop()
    {
        indicator.SetActive(true);
        shopCanvas.SetActive(false);
        shopOpen = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inCollider = true;
            indicator.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            indicator.SetActive(false);
            inCollider = false;
            shopCanvas.SetActive(false);
            shopOpen = false;
        }
    } 
}
