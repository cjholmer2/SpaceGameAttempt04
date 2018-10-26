using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear : MonoBehaviour
{
    public GameObject gearCanvas;
    public GameObject indicator;
    public Button gearTab;
    public GameObject gearPanel;
    public Button colorTab;
    public GameObject colorPanel;
    private bool inCollider = false;
    private bool gearOpen = false;

    void Start()
    {
        EditGear();
        gearCanvas.SetActive(false);
        indicator.SetActive(false);
    }
    void Update()
    {
        if(inCollider == true && gearOpen == false)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Fire1"))
            {
                OpenGear();
            }
        }
    }

    public void OpenGear()
    {
        indicator.SetActive(false);
        gearCanvas.SetActive(true);
        gearOpen = true;
    }

    public void ExitGear()
    {
        indicator.SetActive(true);
        gearCanvas.SetActive(false);
        gearOpen = false;
    }

    public void EditGear()
    {
        gearPanel.SetActive(true);
        gearTab.interactable = false;
        colorPanel.SetActive(false);
        colorTab.interactable = true;
    }

    public void EditColor()
    {
        colorPanel.SetActive(true);
        colorTab.interactable = false;
        gearPanel.SetActive(false);
        gearTab.interactable = true;
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
            gearCanvas.SetActive(false);
            gearOpen = false;
        }
    } 
}
