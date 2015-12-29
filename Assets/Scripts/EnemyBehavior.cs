using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {

    public List<Waypoint> waypoints;
    public int waypointIndex;
    public float startTime;
    public float distance;
    public float distanceTraveled;
    public float distanceFraction;
    public float travelTime;
    public Waypoint startWaypoint, endWaypoint;

    public virtual void Start()
    {
        waypoints = new List<Waypoint>();
        waypointIndex = 0;
        startTime = Time.time;
    }

    // Use this for initialization    
    public virtual void Action(Transform transform)
    {
        if (startWaypoint == null || (distanceFraction >= 1f && waypointIndex < waypoints.Count - 1))
        {
            setNextWaypoint();
            waypointIndex++;
            
        }
    }

    public void setNextWaypoint()
    {
        startWaypoint = waypoints[waypointIndex];
        endWaypoint = waypoints[waypointIndex + 1];
        travelTime = endWaypoint.time - startWaypoint.time;
        distance = Vector3.Distance(startWaypoint.position, endWaypoint.position);
        distanceFraction = distanceTraveled / distance;
        
        startTime = Time.time;
    }
}
