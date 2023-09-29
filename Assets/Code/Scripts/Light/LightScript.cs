using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
   
    public GameObject Light;
    public Transform PlayerHand;

    private bool activo;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (activo == true)
        {
            if (Input.GetKey(KeyCode.S))
            
            {
                Light.transform.SetParent(PlayerHand);
                Light.transform.position = PlayerHand.position;
                Light.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }


        if (other.tag == "Player")
        {
            activo = true;
            Debug.Log("Collition Completed");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 9f);
            audioSource.Play();
            

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
