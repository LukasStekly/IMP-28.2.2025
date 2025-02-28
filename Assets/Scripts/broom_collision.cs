using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class broom_collision : MonoBehaviour
{
    [SerializeField] private Animator broom;//zvolím animaci koštìte

    

    private void OnTriggerStay(Collider collinder)
    {
        if (collinder.gameObject.CompareTag("Player")) //kontrola jestli to je hráè
        {
            if (!broom.GetBool("Fall") && Input.GetKey(KeyCode.E))
            {
                broom.SetBool("Fall", true);//spuštìní animace
                
            }
        }
    }

    
}
