using System;
using Unity.VisualScripting;
using UnityEngine;

// Love you aarthificial
[Serializable]
public struct Optional<T>
{
    [SerializeField] private bool extant;
    [SerializeField] private T value;


    private Optional(T initial_value, bool initial_extant)
    {
        extant = initial_extant;
        value = initial_value;
    }

    public Optional(T initial_value)
    {
        extant = true;
        value = initial_value;
    }

    public static Optional<T> None()
    {
        return new Optional<T>(default(T), false);
    }

    public bool Extant => extant;
    public T Value => value;

}