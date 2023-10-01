using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextSceneF : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
      
        SceneManager.LoadScene("OnlyLevel4444", LoadSceneMode.Single);

    }
}

