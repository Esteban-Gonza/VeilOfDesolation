using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRb : MonoBehaviour
{
    private Rigidbody2D WeaponRbody; 
    public float Speed;

 
    void Start()
    {
        WeaponRbody = GetComponent<Rigidbody2D>();
        
    }

    //Velocity and destroy the weapon
    void Update()
    {
        WeaponRbody.velocity = new Vector2(+Speed * Time.deltaTime, 0);
        Destroy( gameObject, 3f);
    }
}
