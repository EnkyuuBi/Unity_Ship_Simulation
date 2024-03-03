using UnityEngine;

public abstract class Accumulator<T> : MonoBehaviour
{
    [SerializeField]
    protected Dealer<T> dealer;
    protected int id;
    [SerializeField]
    protected T value;

    void Start()
    {
        Consign(dealer);
    }

    protected void Consign(Dealer<T> dealer)
    {
        id = dealer.Add(value);
    }
    protected void Remove()
    {
        dealer.Remove(id);
    }
}


