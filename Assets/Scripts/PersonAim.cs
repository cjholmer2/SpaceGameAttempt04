using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAim : MonoBehaviour
{
    Camera cam;
    public GameObject projectile;
    public bool melee = false;
    public GameObject meleeTemp;

    void Start()
    {
        cam = Camera.main;
    }

    void Update ()
    {
        transform.up = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y) - transform.position;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            if (melee == true && meleeTemp == null)
            {
                meleeTemp = Instantiate(projectile, transform.position, transform.rotation, transform);
            }
            else if(melee == false)
            {
                Instantiate(projectile, transform.position, transform.rotation, null);
            }
        }
    }
}
