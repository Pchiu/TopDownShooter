using UnityEngine;
using System.Collections;

public class TestEnemyBehavior : EnemyBehavior {

    public override void Start()
    {
        base.Start();
        waypoints.Add(new Waypoint(new Vector3(0, 5, 0), 0, 0));
        waypoints.Add(new Waypoint(new Vector3(0, 3, 0), 0.5f, 0));
        waypoints.Add(new Waypoint(new Vector3(3, 3, 0), 2, 0));

        
        
    }

    public override void Action(Transform transform)
    {
        base.Action(transform);
        distanceTraveled = (Time.time - startTime) / travelTime;
        distanceFraction = distanceTraveled / distance;
        transform.position = Vector3.Lerp(startWaypoint.position, endWaypoint.position, distanceFraction);
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
