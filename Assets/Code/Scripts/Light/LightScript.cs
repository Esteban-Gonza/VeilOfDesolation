using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
   
    public GameObject Light;
    public Transform PlayerHand;

    private bool activo;

    void update()
    {
        

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activo = true;
            Debug.Log("Collition Completed");

        }
        if (activo == true)
        {
            if (Input.GetKey(KeyCode.S))
            
            {
                Light.transform.SetParent(PlayerHand);
                Light.transform.position = PlayerHand.position;
                Light.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        

    }

   private void OnTriggerExit2D(Collider2D other) 
    { 
        if (other.tag == "Player") 
        {
            activo = false;
        }
    }
}
