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

    public List<TodoList> items;
    public bool addItem = false;
    public bool removeCompleted = false;

    void OnValidate()
    {
        if(addItem)
        {
            items.Add(new TodoList());
            addItem = false;
        }

        if(removeCompleted)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].complete)
                {
                    items.RemoveAt(i);
                }
            }
            removeCompleted = false;
        }
    }
}

