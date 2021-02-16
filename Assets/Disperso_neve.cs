using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Disperso_neve : InteractablePerson
{
    public bool canUseSonda;
    public bool ArtvaActive;
    public bool isUsingPala;
    public int flag;
    // Start is called before the first frame update
    new void Start()
    {
        flag = 0;
        canUseSonda = false;
        ArtvaActive = false;
        isUsingPala = false;
    }

    new private void Update()
    {
        GameObject.Find("FrecciaSolida").GetComponent<Renderer>().enabled = ArtvaActive;

            dialogue = GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogue_bool;
            interact = dialogue;
        if (interact == false)
        {
            GetComponent<AudioSource>().Stop();
        }
        if (this.GetComponent<Disperso_neve>().GetInteract() && this.GetComponent<Disperso_neve>().dialogue)
            flag = 1;
        if (flag == 1 && this.GetComponent<Disperso_neve>().dialogue == false)
            flag = 2;
    }

    public override void GlowUp(GameObject changeColor)
    {
        if (!interact)
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
        if (((collectable == true && collect == true) && !dialogue) || (collectable == false && !dialogue))
        {
            dialoguetrigger.TriggerDialogue();
            Debug.Log("dialogo");
            GetComponent<AudioSource>().PlayOneShot(dialogo, 1f);
            //do dialogue
        }
        TurnOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        canUseSonda = true;
    }

    public bool GetCanUseSonda()
    {
        return canUseSonda;
    }
    public bool GetArtvaActive()
    {
        return ArtvaActive;
    }
    public bool GetisUsingPala()
    {
        return isUsingPala;
    }
    public void SetArtvaActive(bool valore)
    {
        ArtvaActive = valore;
    }

    internal void SetIsUsingPala(bool v)
    {
        isUsingPala = v;
    }
}
