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
}
