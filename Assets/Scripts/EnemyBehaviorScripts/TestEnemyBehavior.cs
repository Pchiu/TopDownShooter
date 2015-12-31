using UnityEngine;
using System.Collections;

public class TestEnemyBehavior : EnemyBehavior {

    public override void Start()
    {
        base.Start();       
        waypoints.Add(new Waypoint(new Vector3(0, 3, 0), 1, MovementType.Absolute));
        waypoints.Add(new Waypoint(new Vector3(2, 0, 0), 2, MovementType.Relative));
    }

    public override void Action()
    {
        base.Action();
        distanceTraveled = (Time.time - startTime) / travelTime;
        distanceFraction = distanceTraveled / distance;
        transform.position = Vector3.Lerp(startPosition, endPosition, distanceFraction);
    }

    public void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }
    }
}
