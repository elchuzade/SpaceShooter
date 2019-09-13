using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public string bulletType;
    public float speed;
    public float fireRate;

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
    public void SetType(string typeOfBullet)
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
}
