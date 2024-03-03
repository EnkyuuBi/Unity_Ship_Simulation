// Move Behvaiour defines "how" the ship wants to act
// Communicates via waypoints

using System;
using UnityEditor;
using UnityEngine;

[Serializable]
// Contains a world-space vector2, and a world space angle to tell a ship where to go
public struct Waypoint
{
    // World space location
    public Vector2 location;
    // world space angle
    public Optional<Vector2> angle;

    public Waypoint(Vector2 location)
    {
        this.location = location;
        angle = Optional<Vector2>.None();
    }

    public Waypoint(Vector2 location, Vector2 angle)
    {
        this.location = location;
        this.angle = new Optional<Vector2>(angle);
    }
}

// Just unity things
// Can't serialize an interface directly so we need to define a base class that implements the interface only
// I hate this workaround since we can't easily use polymorphic behaviour
// But most classes shouldn't need one more base class otherwise they should be seperate classes anyway.
public abstract class MoveBehaviour : ScriptableObject, IMoveBehaviour
{
    public Vector2 aim_point {get; set;}
    public abstract void draw();
    public abstract Waypoint Get_next_waypoint(Transform self);
}

public interface IMoveBehaviour
{
    Vector2 aim_point {get; set;} // Target Point
    public abstract void draw();
    public abstract Waypoint Get_next_waypoint(Transform self);
}