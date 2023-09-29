using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRb : MonoBehaviour
{
    private Rigidbody2D WeaponRbody; 
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        WeaponRbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponRbody.velocity = new Vector2(+Speed,0);
    }
}
