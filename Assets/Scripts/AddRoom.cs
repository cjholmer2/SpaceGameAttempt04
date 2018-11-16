using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;

    void Start()
    {
        GameObject templatesTemp = GameObject.FindGameObjectWithTag("Rooms");
        if(templatesTemp != null)
        {
            templates = templatesTemp.GetComponent<RoomTemplates>();
            templates.rooms.Add(this.gameObject);
        }
    }
}