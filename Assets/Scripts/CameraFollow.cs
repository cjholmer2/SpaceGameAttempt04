using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public bool targetPlayer = true;
    [Range(0, 250)]
    public float distance = 100;
    public float followSpeed = 0.1f;
    public bool setChanges = false;

    public float testShakeMagnitude;
    public int testShakes;
    public float testShakeSpeed;
    public bool testShake = false;

	// Use this for initialization
	void Start ()
    {
		if(targetPlayer || target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position =  Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z), followSpeed);
    }

    /// <summary>
    /// Shakes the camera.
    /// </summary>
    /// <param name="shakeMagnitude">How far the camera will move from it's original spot</param>
    /// <param name="shakes">Number of times the camera will shake.</param>
    /// <param name="shakeSpeed">Time between each shake.</param>
    /// <returns></returns>
    public IEnumerator CameraShake(float shakeMagnitude, int shakes, float shakeSpeed = 0.5f)
    {
        Vector3 camTemp = transform.position;
        WaitForSeconds wfs = new WaitForSeconds(shakeSpeed);
        float tempFollowSpeed = followSpeed;
        followSpeed = 0;
        for(int i = 0; i < shakes; i++)
        {
            transform.position = camTemp + new Vector3(Random.Range(-shakeMagnitude, shakeMagnitude), Random.Range(-shakeMagnitude, shakeMagnitude));
            yield return wfs;
        }
        followSpeed = tempFollowSpeed;
    }

    void OnValidate()
    {
        GetComponent<Camera>().orthographicSize = distance;
        if(setChanges)
        {
            if(targetPlayer)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            setChanges = false;
        }
        else if(testShake)
        {
            StartCoroutine(CameraShake(testShakeMagnitude, testShakes, testShakeSpeed));
            testShake = false;
        }
    }
}
