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
        SetType("main");
        SetDamage(frontBulletDamage);
        SetSpeed(frontBulletSpeed);
        SetFireRate(frontBulletFireRate);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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