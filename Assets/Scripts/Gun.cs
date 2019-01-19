using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, I_Fireable
{
    public enum FireMode { Single, Burst, Auto }
    public Projectile projectile;
    public float damage;
    public FireMode fireMode;
    public float fireRate;
    public float velocity;
    public float projectileLifetime;
    public int maxAmmo;
    int ammo;
    public int clipSize;
    public float reloadTime;
    bool reloading;
    public Sprite gunSprite;
    Projectile temp;
    public bool friendly;

    private void Awake()
    {
        temp = new Projectile(damage, velocity, projectileLifetime, friendly);
    } 

    public void DisplayUI()
    {
        throw new NotImplementedException();
    }

    public void Fire()
    {
        throw new NotImplementedException();
    }

    public void Reload()
    {
        throw new NotImplementedException();
    }
}
