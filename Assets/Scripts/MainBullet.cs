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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("feifj");
        if (collision.gameObject.name == "LeftWall" ||
            collision.gameObject.name == "RightWall" ||
            collision.gameObject.name == "TopWall" ||
            collision.gameObject.name == "BottomWall")
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
