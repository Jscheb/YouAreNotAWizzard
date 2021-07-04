using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCode2 : MonoBehaviour
{

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

    }


}
