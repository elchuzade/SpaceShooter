using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    private int waypointIndex;
    [SerializeField] float enemySpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        Debug.Log(waypoints[waypointIndex].position.x + " - " + waypoints[waypointIndex].position.y);
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = enemySpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
