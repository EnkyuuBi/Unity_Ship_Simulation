using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int max_health;
    private int current_health;

    void Start()
    {
        current_health = max_health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Damage temp = collision.gameObject.GetComponent<Damage>();
        if (temp != null)
        {
            current_health -= temp.damage;
            if(current_health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
