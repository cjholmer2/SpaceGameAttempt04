using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticsManager : MonoBehaviour
{
    public bool playerSafe;
    public bool spawnersActive;

    void Awake()
    {
        Statics.playerSafe = playerSafe;
        Statics.spawnersActive = spawnersActive;
    }

    private void OnValidate()
    {
        Statics.playerSafe = playerSafe;
        Statics.spawnersActive = spawnersActive;
    }

    void SetPlayerSafe(bool safe)
    {
        playerSafe = safe;
        Statics.playerSafe = safe;
    }

    void SetSpawnersActive(bool active)
    {
        spawnersActive = active;
        Statics.spawnersActive = active;
    }
}
