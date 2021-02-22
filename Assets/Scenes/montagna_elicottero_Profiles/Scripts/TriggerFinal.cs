using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinal : MonoBehaviour
{
    [SerializeField] private GameObject _elicopter;
    [SerializeField] private GameObject _barella;
    private Collider _collider;
    private int flag=0;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == _barella.GetComponent<BoxCollider>() && _barella.transform.childCount == 1 && _barella.transform.parent==this.transform.parent)
        {
            transform.GetComponent<LightUpInteractable>().enabled = true;
            transform.GetComponent<LightUpInteractable>().SetCollectable(false);
            transform.GetComponent<LightUpInteractable>().SetAnimatable(true);
            GameObject.Find("NPC").GetComponent<DialogueTriggerHelicopter>().dialogue = GameObject.Find("DialogoColleghi5");
            if (flag == 0)
            {
                flag++;
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().startDialogue = true;
            }
        }
    }
}

