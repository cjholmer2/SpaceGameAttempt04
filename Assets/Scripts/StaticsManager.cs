using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticsManager : MonoBehaviour
{
    public bool playerCanFire;
    public bool playerSafe;
    public bool friendlyFire;
    public bool spawnersActive;

    void Awake()
    {
        Statics.playerCanFire = playerCanFire;
        Statics.playerSafe = playerSafe;
        Statics.friendlyFire = friendlyFire;
        Statics.spawnersActive = spawnersActive;
    }

    private void OnValidate()
    {
        Statics.playerCanFire = playerCanFire;
        Statics.playerSafe = playerSafe;
        Statics.friendlyFire = friendlyFire;
        Statics.spawnersActive = spawnersActive;
    }

    public void SetPlayerCanFire(bool can)
    {
        playerCanFire = can;
        Statics.playerCanFire = can;
    }

    public void SetPlayerSafe(bool safe)
    {
        playerSafe = safe;
        Statics.playerSafe = safe;
    }

    public void SetFriendlyFire(bool fire)
    {
        friendlyFire = fire;
        Statics.friendlyFire = fire;
    }

    public void SetSpawnersActive(bool active)
    {
        spawnersActive = active;
        Statics.spawnersActive = active;
    }

}
