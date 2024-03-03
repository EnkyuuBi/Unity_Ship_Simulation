using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Thing To spawn")]
    [SerializeField] ObjectPool pool;

    [Header("Spawn Details")]
    [SerializeField] float fire_rate;
    //[SerializeField] Vector2 offset;


    // I swear I've seen like 10 different ways to shoot a gun
    // there's Coroutines, update loop calculatinons, timed invokes???
    // I swear I'm losing my mind
    private bool CanFire() => time_since_last_shot > (1.0f/ (fire_rate / 60.0f));  
    private float time_since_last_shot = 0.0f;
    
    
    public void Fire()
    {
        if(CanFire())
        { 
            GameObject temp = pool.Take_Single();
            if (temp == null)
            {
                return;
            }
            temp.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+0.1f);
            temp.transform.rotation = transform.rotation;
            
            temp.SetActive(true);
            time_since_last_shot = 0.0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_since_last_shot += Time.deltaTime;
        Fire();
    }
}
