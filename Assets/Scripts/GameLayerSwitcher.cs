using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayerSwitcher : MonoBehaviour
{
    public GameObject shipCamera;
    public GameObject person;
    public GameObject personCamera;
    
    private bool inside = false;

    public Transform enterPoint;
    public Transform exitPoint;

    public GameObject shipTemp;

    void Start()
    {
        shipCamera = GameObject.FindGameObjectWithTag("Camera");
        person = GameObject.FindGameObjectWithTag("PlayerPerson");
        personCamera = GameObject.FindGameObjectWithTag("CameraPerson");
        person.SetActive(false);
        personCamera.SetActive(false);
    }
    

    public void EnterInterior()
    {
        person.SetActive(true);
        personCamera.SetActive(true);
        person.transform.position = enterPoint.position;
        shipCamera.SetActive(false);
        
        inside = true;
    }

    public void EnterSpace()
    {
        shipCamera.SetActive(true);
        shipTemp.transform.position = exitPoint.position;
        person.SetActive(false);
        personCamera.SetActive(false);
        inside = false;
        shipTemp = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerPerson"))
        {
            if(!inside)
            {
                shipTemp = other.gameObject;
                shipTemp.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                shipTemp.GetComponent<PlayerController>().enabled = false;
                EnterInterior();
            }
            else
            {
                shipTemp.GetComponent<PlayerController>().enabled = true;
                EnterSpace();
            }
        }
    }
}
