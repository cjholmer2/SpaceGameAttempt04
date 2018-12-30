using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Styles : MonoBehaviour
{
    public GUIStyle shieldStyle;
    public static GUIStyle shield;

    public Texture box;
    public static Texture boxTexture;

    public Color hpColor;
    public static Color healthColor;


    public Color shColor;
    public static Color shieldColor;

    void OnValidate()
    {
        shield = shieldStyle;
        boxTexture = box;
        healthColor = hpColor;
        shieldColor = shColor;
    }
}
