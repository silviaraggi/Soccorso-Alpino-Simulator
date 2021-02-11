using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerHelicopter : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public bool dialogue_bool;
    public Animator animator;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogue_bool = false;

    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonCharacterControllerHelicopter>().SetLocked(true);
        dialogue_bool = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }



    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }



    void EndDialogue()
    {
        Debug.Log("fine");
        animator.SetBool("IsOpen", false);
        dialogue_bool = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInteractionManagerHelicopter>().SetUnlocked(true);

    }

}
