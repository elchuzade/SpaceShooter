using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] Sprite basicEnemy;
    [SerializeField] int basicEnemyHealthPoints;
    [SerializeField] int basicEnemySpeed;

    private void Awake()
    {
        SetEnemyType("basic");
        SetEnemyHealthPoints(basicEnemyHealthPoints);
        SetEnemySpeed(basicEnemySpeed);
    }

    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(basicEnemySpeed, -basicEnemySpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "MainBullet")
        {
            // hit main bullet
            Debug.Log("main bullet");
        }
        if (collision.gameObject.name == "FrontBullet")
        {
            Debug.Log("front bullet");
        }
        if (collision.gameObject.name == "SideBullet")
        {
            Debug.Log("side bullet");
        }
    }
}
