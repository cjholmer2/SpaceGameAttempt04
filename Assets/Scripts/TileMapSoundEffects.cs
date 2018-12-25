using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapSoundEffects : MonoBehaviour
{
    AudioSource sound;

    private void OnTransformParentChanged()
    {
        Debug.Log("plop2");
        sound.Play();
    }

    private void OnValidate()
    {
        Debug.Log("plop3");
        if(sound == null)
        {
            sound = GetComponent<AudioSource>();
        }
        sound.Play();
    }
}
