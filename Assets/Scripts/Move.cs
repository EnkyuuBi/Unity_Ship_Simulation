using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Affector<EngineStat>
{
    [SerializeField] public Vector2 target_position;
    [SerializeField] public EngineStat speed;

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
        Vector2 offset = target_position - (Vector2)transform.position;
        Vector2 dir = offset.normalized;

        Vector2 minstep = Vector2.Min(dir * speed.forward_speed * Time.deltaTime, offset);
        transform.position += (Vector3) minstep;    
    }
}
