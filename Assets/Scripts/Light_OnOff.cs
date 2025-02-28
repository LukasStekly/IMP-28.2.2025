using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_OnOff : MonoBehaviour
{
    public GameObject switchoff, switchon, light1,light2, sedm;
    bool light; // pro kontrolu, zda je rozsviceno nebo zhasnuto
     private void OnTriggerStay(Collider collinder)
     {
         if (collinder.gameObject.tag == "Player")
         {
             if (Input.GetKeyDown(KeyCode.E))
             {
                 light = !light;

                 if (light) // aktivace svìtla
                 {
                     light1.SetActive(true);
                     light2.SetActive(true);
                     switchon.SetActive(true);
                     switchoff.SetActive(false);
                     sedm.SetActive(false);
                 }
                 else // deaktivace svìtla
                 {
                    light1.SetActive(false);
                    light2.SetActive(false);
                    switchon.SetActive(false);
                    switchoff.SetActive(true);
                    sedm.SetActive(true);
                }
             }
         }
     }
}
