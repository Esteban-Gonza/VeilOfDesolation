using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform Weapon;
    public GameObject WeaponRb;

   void Update()
   {
     if(Input.GetKey(KeyCode.Space))
     {
        Instantiate(WeaponRb, Weapon.position, Quaternion.identity);
     }
   }
}
