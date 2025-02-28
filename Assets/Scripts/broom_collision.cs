using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class broom_collision : MonoBehaviour
{
    [SerializeField] private Animator broom;//zvol�m animaci ko�t�te

    

    private void OnTriggerStay(Collider collinder)
    {
        if (collinder.gameObject.CompareTag("Player")) //kontrola jestli to je hr��
        {
            if (!broom.GetBool("Fall") && Input.GetKey(KeyCode.E))
            {
                broom.SetBool("Fall", true);//spu�t�n� animace
                
            }
        }
    }

    
}
