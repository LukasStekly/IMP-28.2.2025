using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sicker_trigger : MonoBehaviour
{
    public GameObject SICKERCANVAS;

    public bool read = false;

    void Start()
    {
        SICKERCANVAS.SetActive(false);
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
                    SICKERCANVAS.SetActive(true);


                }

                else
                {
                    SICKERCANVAS.SetActive(false);
                    read = false;
                }

            }
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            SICKERCANVAS.SetActive(false);
            read = false;

        }
    }
}
