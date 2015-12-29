using UnityEngine;
using System.Collections;

public class Waypoint{

    public Vector3 position;
    public float time;
    public int movementType;

    public Waypoint(Vector3 position, float time, int movementType)
    {
        this.position = position;
        this.time = time;
        this.movementType = movementType;
    }
}
