using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Todo/Note")]
public class Note : MonoBehaviour
{
    [TextArea(1, 30)][SerializeField]
    public string note;
}
