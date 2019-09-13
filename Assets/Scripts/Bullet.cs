using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public string bulletType;

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
}
