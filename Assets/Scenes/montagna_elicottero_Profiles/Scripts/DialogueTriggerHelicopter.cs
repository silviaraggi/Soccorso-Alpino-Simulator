using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTriggerHelicopter : MonoBehaviour
{

    public GameObject dialogue;

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManagerHelicopter>().StartDialogue(dialogue.GetComponent<DialogueItem>().dialogo);
    }

}
