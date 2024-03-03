using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct EngineStat
{
    public float forward_speed;
    public float back_speed;
    public float left_speed;    
    public float right_speed;
    public float turn_speed;

    public static EngineStat operator +(EngineStat A, EngineStat B)
    {
        A.forward_speed += B.forward_speed;
        A.back_speed += B.back_speed;
        A.left_speed += B.left_speed;
        A.right_speed += B.right_speed;
        A.turn_speed += B.turn_speed;
        return A;
    }

    public static EngineStat operator -(EngineStat A, EngineStat B)
    {
        A.forward_speed -= B.forward_speed;
        A.back_speed -= B.back_speed;
        A.left_speed -= B.left_speed;
        A.right_speed -= B.right_speed;
        A.turn_speed -= B.turn_speed;
        return A;
    }
}

public class Engine : Accumulator<EngineStat>
{
    void OnDisable()
    {
        dealer.Remove(id);
    }
}
