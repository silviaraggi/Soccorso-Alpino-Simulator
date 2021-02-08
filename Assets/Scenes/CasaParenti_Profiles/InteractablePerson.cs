using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePerson : Interactable
{
    public bool animatable; //dialogable
    public bool collectable; //follow
    public bool interact = false; //dialog
    public bool collect = false; //follow
    public DialogueTrigger dialoguetrigger;
    public bool dialogue = false;
    Material[] mat;


    // Start is called before the first frame update
    protected override void Start()
    {
        if (gameObject.GetComponent<Renderer>())
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            mat = GetComponent<Renderer>().materials;
        }
        if (gameObject.GetComponent<Collider>())
            gameObject.GetComponent<Collider>().enabled = true;

    }


    public void Update()
    {
        if (this.animatable)
        {
            dialogue = GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogue_bool;
            interact = dialogue;
        }
    }

    public override void GlowUp(GameObject changeColor)
    {
        if (!interact&&!collect)
        {
            {
               /* if (mat != null)
                {
                    for (int i = 0; i < mat.Length; i++)
                    {
                        mat[i].EnableKeyword("_EMISSION");
                        mat[i].SetColor("_EmissionColor", new Vector4(0.15f, 0.30f, 0.30f, 0));
                    }
                }*/
                //else
                {
                    /*if (changeColor.transform.GetComponent<Renderer>())
                    {
                        mat = changeColor.transform.GetComponent<Renderer>().materials;
                        if (mat != null)
                        {
                            for (int i = 0; i < mat.Length; i++)
                            {
                                mat[i].EnableKeyword("_EMISSION");
                                mat[i].SetColor("_EmissionColor", new Vector4(0.30f, 0.30f, 0.30f, 0));
                            }
                        }
                    }*/
                    Transform[] allChildren = GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren)
                    {
                        if (child.gameObject.GetComponent<Renderer>())
                        {
                            if (child.gameObject.GetComponent<Renderer>().materials.Length > 0)

                                for (int i = 0; i < child.gameObject.GetComponent<Renderer>().materials.Length; i++)
                                {
                                    child.gameObject.GetComponent<Renderer>().materials[i].EnableKeyword("_EMISSION");
                                    child.gameObject.GetComponent<Renderer>().materials[i].SetColor("_EmissionColor", new Vector4(0.15f, 0.30f, 0.30f, 0));
                                }
                        }

                    }
                }
            }
        }
        

    }

    public override void TurnOff()
    {
        /*if (mat != null)
            for (int i = 0; i < mat.Length; i++)
            {
                mat[i].DisableKeyword("_EMISSION");
            }
        else
        {*/
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.gameObject.GetComponent<Renderer>())
                {
                    if (child.gameObject.GetComponent<Renderer>().materials.Length > 0)

                        for (int i = 0; i < child.gameObject.GetComponent<Renderer>().materials.Length; i++)
                        {
                            child.gameObject.GetComponent<Renderer>().materials[i].DisableKeyword("_EMISSION");
                        }
                }
            }
        //}

    }


    public override void Interact(GameObject interacter)
    {
        if (!collectable&&!dialogue)
        {
            dialoguetrigger.TriggerDialogue();
            //do dialogue
        }
        else
        {
            collect = true;
            GetComponent<SC_NPCFollow>().enabled = true;
        }
        TurnOff();
    }

    public override bool GetAnimatable()
    {
        return animatable;
    }
    public override bool GetCollectable()
    {
        return collectable;
    }
    public override bool GetInteract()
    {
        return interact;
    }

    public override bool GetCollect()
    {
        return collect;
    }
    public override void SetAnimatable(bool newvalue)
    {
        animatable = newvalue;
    }
    public override void SetCollectable(bool newvalue)
    {
        collectable = newvalue;
    }
    public override void SetInteract(bool newvalue)
    {
        interact = newvalue;
    }
    public override void SetCollect(bool newvalue)
    {
        collect = newvalue;
    }

}


