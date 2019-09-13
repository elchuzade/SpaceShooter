using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBullet : Bullet
{
    [SerializeField] Sprite mainBullet;
    [SerializeField] int mainBulletDamage;
    [SerializeField] float mainBulletSpeed;
    [SerializeField] float mainBulletFireRate;

    private void Awake()
    {
        SetBulletType("main");
        SetDamage(mainBulletDamage);
        SetSpeed(mainBulletSpeed);
        SetFireRate(mainBulletFireRate);
    }

    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, mainBulletSpeed);
    }

    public Vector3 GetOffset()
    {
        return new Vector3(0f, 120f, 0f);
    }
}
