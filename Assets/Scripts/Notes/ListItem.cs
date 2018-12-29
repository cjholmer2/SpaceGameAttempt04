using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Todo/List")]
public class ListItem : MonoBehaviour
{
    [System.Serializable]
    public struct TodoList
    {
        public string description;
        public bool complete;
    }

    public TodoList[] items;
}

