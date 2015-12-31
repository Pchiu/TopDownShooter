using UnityEngine;
using System.Collections;

public class Waypoint{

    public Vector3 position;
    public float time;
    public MovementType movementType;

    public Waypoint(Vector3 position, float time, MovementType movementType)
    {
        this.position = position;
        this.time = time;
        this.movementType = movementType;
    }
}

public enum MovementType
{
    Absolute,
    Relative
}

