using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCode : MonoBehaviour
{
    DialogueTrigger trigger1;
    SpawnEnemy spawn1;
    [SerializeField]
    private DialogueManager manager;

    // Start is called before the first frame update
    void Start()
    {
        trigger1 = GameObject.Find("/01DialogueFirstContact").GetComponent<DialogueTrigger>();
        spawn1 = GameObject.Find("/01DialogueFirstContact").GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (manager.dialogueEnded)
        {
            manager.dialogueEnded = false;
            if (trigger1.isTriggered)
            {
                spawn1.createEnemy();
            }
        }
    }
}
