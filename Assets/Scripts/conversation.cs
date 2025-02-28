using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;


public class conversation : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider collinder)
    {
        if (collinder.gameObject.tag =="Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }
}
