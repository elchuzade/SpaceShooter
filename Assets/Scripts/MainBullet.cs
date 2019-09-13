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
        SetType("main");
        SetDamage(mainBulletDamage);
        SetSpeed(mainBulletSpeed);
        SetFireRate(mainBulletFireRate);
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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, mainBulletSpeed);
    }

    public Vector3 GetOffset()
    {
        return new Vector3(0f, 120f, 0f);
    }
}
