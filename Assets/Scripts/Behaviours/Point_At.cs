// This should call the AI to point at an aim_point and maintain a certain distance.


using UnityEngine;

[CreateAssetMenu(fileName = "Point_At", menuName = "Scriptable Objects/Behaviours")]
public class Point_At_Behaviour : MoveBehaviour
{

    [Header("Behaviour Settings")]
    public float goal_distance_away_from_target;
    public float max_variance;

    Waypoint cache {get; set;}

    public override Waypoint Get_next_waypoint(Transform self)
    {
        Vector2 offset = aim_point - (Vector2)self.position;
        float distance = offset.magnitude;

        float offset_dir = distance - goal_distance_away_from_target;
        float variance = Mathf.Abs(offset_dir); 

        if (variance < max_variance)
        {
            return cache;
        }
        else
        {
            Vector2 new_dir = offset.normalized;
            Vector2 position = -new_dir * goal_distance_away_from_target + aim_point;

            Waypoint point = new Waypoint(position, new_dir);
            cache = point;
            return point;
        }
    }

    public override void draw()
    {
        // Draw a RED cirlce around the goal distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(aim_point, goal_distance_away_from_target);
        
        // Draw 2 YELLOW circles, one for the inner, and one for the outer variance limits 
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(aim_point, goal_distance_away_from_target + max_variance);
        Gizmos.DrawWireSphere(aim_point, goal_distance_away_from_target- max_variance);
    }
}