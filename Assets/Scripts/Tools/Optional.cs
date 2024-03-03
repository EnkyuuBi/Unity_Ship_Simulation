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

    /// <summary>
    /// Creates a optional with a none.
    /// </summary>
    /// <returns>An Optional with a none value, and a non-usable value</returns>
    public static Optional<T> None()
    {
        return new Optional<T>(default(T), false);
    }

    /// <summary>
    /// Creates a optional with a none and usable value.
    /// </summary>
    /// <returns>An Optional with a none value, and a usable value</returns>
    public static Optional<T> None(T value)
    {
        return new Optional<T>(value, false);
    }

    public bool Extant => extant;
    public T Value => value;

}