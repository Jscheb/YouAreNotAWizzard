using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCode : MonoBehaviour
{
    DialogueTrigger trigger1;
    SpawnEnemy spawn1;
    [SerializeField]
    private DialogueManager manager;


    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
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
                trigger1.isTriggered = false;
                spawn1.createEnemy();
            }
        }
    }
}
