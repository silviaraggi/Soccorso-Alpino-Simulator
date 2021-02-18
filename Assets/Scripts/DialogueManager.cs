using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueManager : MonoBehaviour
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
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonCharacterControllerSOUND>().SetLocked(true);
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().SetLocked(true);
        dialogue_bool = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
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



    public void EndDialogue()
    {
        Debug.Log("fine");
        animator.SetBool("IsOpen", false);
        dialogue_bool = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FPSInteractionManager>().SetUnlocked(true);

    }

}
