using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSwing : MonoBehaviour
{
    public float speed = 1;
    public float swing = 120;
    private Quaternion end;

    void Start()
    {
        end = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        end.eulerAngles = end.eulerAngles + new Vector3(0, 0, swing);
    }

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, end, speed);
        if(transform.rotation == end)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
