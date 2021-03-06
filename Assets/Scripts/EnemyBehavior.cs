﻿using UnityEngine;
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
    public Vector3 startPosition, endPosition;
    public Transform transform;

    public virtual void Start()
    {
        waypoints = new List<Waypoint>();
        // Push initial position as first waypoint
        waypoints.Add(new Waypoint(transform.position, 0, MovementType.Absolute));
        waypointIndex = 0;
        startTime = Time.time;
    }

    // Use this for initialization    
    public virtual void Action()
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
        if (endWaypoint.movementType == MovementType.Absolute)
        {
            startPosition = startWaypoint.position;
            endPosition = endWaypoint.position;
        }
        else
        {
            startPosition = startWaypoint.position;
            endPosition = startWaypoint.position + endWaypoint.position;
        }

        travelTime = endWaypoint.time - startWaypoint.time;
        distance = Vector3.Distance(startPosition, endPosition);
        distanceFraction = distanceTraveled / distance;
        
        startTime = Time.time;
    }
}
