using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnemyTrigger : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
