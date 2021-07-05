using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isTriggered = false;
    public GameObject abspann;
    

    public void TriggerDialogue()
    {
        abspann.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
