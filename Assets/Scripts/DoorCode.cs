using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    public GameObject codeCanvas;  
    private bool playerInRange = false;  

    void Update()
    {
        
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            codeCanvas.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            codeCanvas.SetActive(false);
        }
    }


}
