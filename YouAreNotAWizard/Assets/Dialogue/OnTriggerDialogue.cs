using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDialogue : MonoBehaviour
{
    DialogueTrigger trigger;

    private void Awake()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        trigger.isTriggered = true;
        CharacterController con = other.GetComponent<CharacterController>();
        if (con != null){
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<DialogueTrigger>().TriggerDialogue();
            GetComponent<MeshRenderer>().enabled = false;
        }


        
    }
}
