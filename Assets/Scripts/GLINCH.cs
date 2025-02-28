using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLINCH : MonoBehaviour
{
    public GameObject GLINCHCANVAS;

    public bool read = false;

    void Start()
    {
        GLINCHCANVAS.SetActive(false);
        read = false;
    }

    private void OnTriggerStay(Collider collinder)
    {

        if (collinder.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!read)
                {
                    read = true;
                    GLINCHCANVAS.SetActive(true);


                }

                else
                {
                    GLINCHCANVAS.SetActive(false);
                    read = false;
                }

            }
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GLINCHCANVAS.SetActive(false);
            read = false;

        }
    }
}
