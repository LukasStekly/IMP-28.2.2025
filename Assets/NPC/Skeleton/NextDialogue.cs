using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    int index = 2;
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if (Move.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if(transform.childCount == index)
                {
                    index = 2;
                    Move.dialogue = false;
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
