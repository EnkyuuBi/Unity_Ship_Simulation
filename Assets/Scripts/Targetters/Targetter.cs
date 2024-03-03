using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  ITargetter : MonoBehaviour
{
    
    /// <summary>
    /// Gets the vector2 of the Targetter's currently tracked target
    /// </summary>
    /// <returns>Optional: Position of the current target</returns>
    public abstract Optional<Vector2> get_target_pos();
}