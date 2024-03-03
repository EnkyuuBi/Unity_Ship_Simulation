using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Affector<T> : MonoBehaviour
{
    public abstract void update_self(T input);
}