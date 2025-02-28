using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System.Diagnostics;

public class Darth_Vader : MonoBehaviour
{
    public GameObject lightsaber;
    public NPCConversation DarthVader;
    public Animator playerAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == lightsaber)
        {
            Destroy(other.gameObject);
            playerAnim.SetTrigger("idle_vader");
            Start_Secrect_Conversation();
        }
    }
    void OnTriggerLeave(Collider other)
    {
        
            playerAnim.ResetTrigger("idle_vader");
        
    }

    private void Start_Secrect_Conversation()
    {
        ConversationManager.Instance.StartConversation(DarthVader);
        ConversationManager.Instance.SetBool("sword", true);
    }
   
}
