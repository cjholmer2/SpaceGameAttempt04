using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetSwitcher : MonoBehaviour
{
    public GameObject[] presets;
    private int preset = 0;
    public bool next = false;

    void OnValidate()
    {
        if(next == true)
        {
            next = false;
            if(presets.Length > 0)
            {
                presets[preset].SetActive(false);
                preset++;
                preset %= presets.Length;
                presets[preset].SetActive(true);
            }
        }
    }
}
