using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class NPC_Script : MonoBehaviour
{
     bool player_detection = false;
    public GameObject canva;
    public GameObject d_template;

    // Update is called once per frame
    void Update()
    {
        
        if (player_detection == true && Input.GetKeyDown(KeyCode.F) && !Move.dialogue)
        {
            canva.SetActive(true);
            Move.dialogue = true;
            NewDialogue("Ahoj!!!");
            NewDialogue("Jmenuji se skeleton.");
            NewDialogue("Rád tì tady vítám mezi nás.");
            NewDialogue("Hi");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialogue (string text)
    {
        GameObject template_clone = Instantiate (d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).gameObject.SetActive (true);
    }

    private void OnTriggerEnter(Collider collinder)
    {
        if (collinder.gameObject.tag == "Player")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider collinder)
    {
        player_detection = false;
    }
}
