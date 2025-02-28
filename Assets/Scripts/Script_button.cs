using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_button : MonoBehaviour
{
    public TV tvScript; // Reference na TV skript
    public GameObject number; // Objekt èísla, který se má aktivovat

    private void OnCollisionEnter(Collision collision)
    {
        // Zajištìní, že hráè mùže aktivovat èíslo
        if (tvScript.Jump_Player && collision.gameObject.CompareTag("Player"))
        {
            number.SetActive(true); // Aktivace èísla
        }
    }
}
