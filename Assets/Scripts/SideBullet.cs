using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBullet : Bullet
{
    [SerializeField] Sprite sideBullet;
    [SerializeField] int sideBulletDamage;
    [SerializeField] float sideBulletSpeed;
    [SerializeField] float sideBulletFireRate;

    private void Awake()
    {
        SetBulletType("side");
        SetDamage(sideBulletDamage);
        SetSpeed(sideBulletSpeed);
        SetFireRate(sideBulletFireRate);
    }

    public void RotateLeft()
    {
        transform.Rotate(new Vector3(0f, 0f, 13f));
    }

    public void RotateRight()
    {
        transform.Rotate(new Vector3(0f, 0f, -13f));
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
        return new Vector3(-112f, -10f, 0f);
    }

    public Vector3 GetOffsetRight()
    {
        return new Vector3(112f, -10f, 0f);
    }
}
