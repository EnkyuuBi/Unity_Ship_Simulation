// Move Manoeuvres define how the ship actually move
using UnityEngine;

public interface IMoveManoeuvre
{
    Vector2 Waypoint {get; set;} // Target Point
    
    public abstract Vector2 Get_next_waypoint();
}