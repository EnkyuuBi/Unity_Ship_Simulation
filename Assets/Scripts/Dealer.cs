using System.Collections.Generic;
using UnityEngine;

public abstract class Dealer<T> : MonoBehaviour 
{
    // TODO: Find out how to do this without a dictionary
    protected Dictionary<int,T> inputs;
    protected T sum;

    [SerializeField]
    public Affector<T> affector;

    void Awake()
    {
        inputs = new Dictionary<int,T>();
        sum = default(T);    
    }

    /// <summary>
    /// Add an accumulator's value to the dealer
    /// </summary>
    /// <param name="change"> value to change</param>
    /// <returns>The id of the Accumulator</returns>
    public int Add(T change)
    {
        int id = inputs.Count;
        Debug.Log("appended " + id + " to dict");
        inputs.Add(id, change);
        sum = add_sum(change);
        affector.update_self(sum);
        return id;
    }

    protected abstract T add_sum(T change);
    protected abstract T subtract_sum(T change);

    public void Remove(int id)
    {
        if (inputs.ContainsKey(id))
        {
            Debug.Log("removing " + id + " from dict");
            subtract_sum(inputs[id]);
            affector.update_self(sum);
            inputs.Remove(id);
        }
    }  
}