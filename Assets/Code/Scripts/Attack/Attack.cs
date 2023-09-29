using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform Weapon;
    public GameObject WeaponRb;

    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

   void Update()
   {
     if(Input.GetKey(KeyCode.Space))
     {
        Instantiate(WeaponRb, Weapon.position, Quaternion.identity);
        audio.Play();
     }

   }
}
