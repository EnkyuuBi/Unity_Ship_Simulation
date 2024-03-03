using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField] float turn_accel;

    [SerializeField] float turn_rate_cap;

    [SerializeField] ITargetter targetter;

    private float rotational_velocity;

    [SerializeField] Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        rotational_velocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Optional<Vector2> temp = targetter.get_target_pos();
        if (temp.Extant)
        {
            Turn_to(temp.Value);
        }
        
        spawner.Fire();
    }

    void Turn_to(Vector2 aim_point)
    {
        if (aim_point != null)
        {
            // src for funky math so that I don't have to write my own rotate function: https://forum.unity.com/threads/look-rotation-2d-equivalent.611044/
            Vector3 rotated = Quaternion.Euler(0, 0, 90)  * ((Vector3)aim_point - transform.position);
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, rotated);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turn_rate_cap);
        }
    }
}
