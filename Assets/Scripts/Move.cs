using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Affector<EngineStat>
{
    [SerializeField] public Vector2 target_position;
    [SerializeField] public EngineStat speed;

    [SerializeField] MoveBehaviour moveBehaviour;

    private Waypoint waypoint;
    public override void update_self(EngineStat input)
    {
        speed = input;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveBehaviour.aim_point = target_position;

        waypoint = moveBehaviour.Get_next_waypoint(transform);
        
        Vector2 offset = waypoint.location - (Vector2)transform.position;
        Vector2 dir = offset.normalized;

        Vector2 tempa = speed.forward_speed * Time.deltaTime * dir;
        Vector2 tempb = offset;

        Vector2 final_move = tempa.magnitude < tempb.magnitude ? tempa : tempb;
        // Vector2 minstep = Vector2.Min(.magnitude, offset.magnitude);
        Debug.Log(final_move);
        transform.position += (Vector3) final_move;    
    }

    void OnDrawGizmos()
    {
        // Draw line to dir
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(waypoint.location - (Vector2)transform.position).normalized);
       
        // Draw line to aimpoint
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target_position);
        
        // Draw line to waypoint
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, waypoint.location);
        
        // Draw Sphere at waypoint
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(waypoint.location, 0.5f);
        
        moveBehaviour.draw();
    }
}
