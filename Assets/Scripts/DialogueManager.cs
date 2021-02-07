using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    private Canvas DialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        DialogueBox = GameObject.Find("Dialogue").GetComponent<Canvas>();
        DialogueBox.enabled = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();
        DialogueBox.enabled = true;
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
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

        string sentence=sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        DialogueBox.enabled = false;
        Debug.Log("End of conversation.");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
