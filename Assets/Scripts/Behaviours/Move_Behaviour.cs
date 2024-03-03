// Move Behvaiour defines "how" the ship wants to act
// Communicates via waypoints

using UnityEngine;

public interface IMoveBehaviour
{
    Vector2 aim_point {get; set;} // Target Point
}