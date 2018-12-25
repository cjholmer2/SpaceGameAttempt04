using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticsManager : MonoBehaviour
{
    public bool playerSafe;

    void Awake()
    {
        Statics.playerSafe = playerSafe;
    }

    private void OnValidate()
    {
        Statics.playerSafe = playerSafe;
    }

    void SetPlayerSafe(bool safe)
    {
        playerSafe = safe;
        Statics.playerSafe = safe;
    }
}
