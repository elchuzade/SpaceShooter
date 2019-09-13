using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBullet : Bullet
{
    [SerializeField] Sprite frontBullet;
    [SerializeField] int frontBulletDamage;
    [SerializeField] float frontBulletSpeed;
    [SerializeField] float frontBulletFireRate;

    private void Awake()
    {
        SetBulletType("front");
        SetDamage(frontBulletDamage);
        SetSpeed(frontBulletSpeed);
        SetFireRate(frontBulletFireRate);
    }

    public void Move()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, frontBulletSpeed);
    }

    public Vector3 GetOffsetLeft()
    {
        return new Vector3(-75f, 40f, 0f);
    }
    public Vector3 GetOffsetRight()
    {
        return new Vector3(75f, 40f, 0f);
    }
}