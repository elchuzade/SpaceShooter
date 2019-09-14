using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int healthPoints;
    private string enemyType;
    private int enemySpeed;

    // Health set and get
    public void SetEnemyHealthPoints(int healthPointsOfEnemy)
    {
        healthPoints = healthPointsOfEnemy;
    }
    public int GetEnemyHealthPoints()
    {
        return healthPoints;
    }
    // Type set and get
    public void SetEnemyType(string typeOfEnemy)
    {
        enemyType = typeOfEnemy;
    }
    public string GetEnemyType()
    {
        return enemyType;
    }
    // Speed set and get
    public void SetEnemySpeed(int speedOfEnemy)
    {
        enemySpeed = speedOfEnemy;
    }
    public int GetEnemySpeed()
    {
        return enemySpeed;
    }
    // Destroy
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    // Decrease health
    public void DecreaseHealthPoints(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            DestroyEnemy();
        }
    }
}
