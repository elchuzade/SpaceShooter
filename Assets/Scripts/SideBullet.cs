using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBullet : Bullet
{
    [SerializeField] Sprite sideBullet;
    [SerializeField] int sideBulletDamage;
    [SerializeField] float sideBulletSpeed;
    [SerializeField] float sideBulletFireRate;
    // Angle of rotation is 13 degrees

    private void Awake()
    {
        SetBulletType("side");
        SetDamage(sideBulletDamage);
        SetSpeed(sideBulletSpeed);
        SetFireRate(sideBulletFireRate);
    }

    public void MoveLeft()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-sideBulletSpeed * Mathf.Sin(13 * Mathf.PI / 180), sideBulletSpeed * Mathf.Cos(13 * Mathf.PI / 180));
    }

    public void MoveRight()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(sideBulletSpeed * Mathf.Sin(13 * Mathf.PI / 180), sideBulletSpeed * Mathf.Cos(13 * Mathf.PI / 180));
    }

    public Vector3 GetOffsetLeft()
    {
        return new Vector3(-110f, 8f, 0f);
    }

    public Vector3 GetOffsetRight()
    {
        return new Vector3(110f, 8f, 0f);
    }
}
