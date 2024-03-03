using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTargetter : ITargetter
{
    public GameObject target{get;}
    public GameObject valid_targets{get;}
    
    
    [SerializeField] float fire_rate;
    private bool CanFire() => time_since_last_shot > (1.0f/ (fire_rate / 60.0f));  
    private float time_since_last_shot = 0.0f;
    
    Vector2 random_location;

    public override Optional<Vector2> get_target_pos()
    {
        return new Optional<Vector2>((Vector2)transform.position + random_location);
    }

    public void Fire()
    {
        if(CanFire())
        { 
           random_location.x = Random.Range(-1.0f, 1.0f);
           random_location.y = Random.Range(-1.0f, 1.0f);
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
