using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public RawImage charleft;
    public RawImage charright;



    public Animator animator;

    private Queue<string> names;
    private Queue<Texture> picturesLeft;
    private Queue<Texture> picturesRight;
    private Queue<string> sentences;
   


    public bool dialogueEnded = false;

    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        picturesLeft = new Queue<Texture>();
        picturesRight = new Queue<Texture>();
        animator.SetBool("IsOpen", false);
    }
    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        dialogueEnded = false;



        sentences.Clear();
        names.Clear();
        picturesLeft.Clear();
        picturesRight.Clear();


        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Texture tex in dialogue.chararcterLeft)
        {
            picturesLeft.Enqueue(tex);
        }
        foreach (Texture tex in dialogue.chararcterRight)
        {
            picturesRight.Enqueue(tex);
        }
        
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string name = names.Dequeue();
        nameText.text = name;
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        Texture left = picturesLeft.Dequeue();
        charleft.texture = left;
        Texture right = picturesRight.Dequeue();
        charright.texture = right;
  
    }

    public void freezeTime()
    {
        if(Time.timeScale > 0.5f)
        {
            Time.timeScale = 0.1f;
        }
        
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        dialogueEnded = true;
        Time.timeScale = 1f;
        
    }


}
