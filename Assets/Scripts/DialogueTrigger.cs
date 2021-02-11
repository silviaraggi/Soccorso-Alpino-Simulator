using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;

    public void TriggerDialogue() {

        if (FindObjectOfType<PickUpMaglia>().collectMagliaIsTrue==false)
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        else if (FindObjectOfType<PickUpMaglia>().collectMagliaIsTrue)
            FindObjectOfType<DialogueManager>().StartDialogue2(dialogue);


    }

}
