using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolo : MonoBehaviour
{
    public Transform target;
    public bool targetPlayer = true;
    [Range(0, 250)]
    public float distance = 100;
    public bool setChanges = false;

	// Use this for initialization
	void Start ()
    {
		if(targetPlayer == true || target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

    void OnValidate()
    {
        GetComponent<Camera>().orthographicSize = distance;
        if(setChanges == true)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            setChanges = false;
        }
    }
}
