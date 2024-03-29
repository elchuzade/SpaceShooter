﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private string bulletType;
    private float speed;
    private float fireRate;

    // Damage set and get
    public void SetDamage(int damageOfBullet)
    {
        damage = damageOfBullet;
    }
    public int GetDamage()
    {
        return damage;
    }
    // Type set and get
    public void SetBulletType(string typeOfBullet)
    {
        bulletType = typeOfBullet;
    }
    public string GetBulletType()
    {
        return bulletType;
    }
    // Speed set and get
    public void SetSpeed(float speedOfBullet)
    {
        speed = speedOfBullet;
    }
    public float GetSpeed()
    {
        return speed;
    }
    // FireRate set and get
    public void SetFireRate(float fireRateOfBullet)
    {
        fireRate = fireRateOfBullet;
    }
    public float GetFireRate()
    {
        return fireRate;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.DecreaseHealthPoints(damage);
            
        }
        DestroyBullet();
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
