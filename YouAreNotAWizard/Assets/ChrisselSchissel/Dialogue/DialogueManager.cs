using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public RawImage charleft;
    public RawImage charright;


    public Animator animator;

    private Queue<Texture> picturesLeft;
    private Queue<Texture> picturesRight;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        picturesLeft = new Queue<Texture>();
        picturesRight = new Queue<Texture>();
    }
    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
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
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        Texture left = picturesLeft.Dequeue();
        charleft.texture = left;
        Texture right = picturesRight.Dequeue();
        charright.texture = right;
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }


}
