using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDialogue : MonoBehaviour
{
    private DialogueManager dia;
    void Start()
    {
        dia = new DialogueManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController con = other.GetComponent<CharacterController>();
        if (con != null){
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
