using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePersonHelicopter : Interactable
{
    public bool animatable; //dialogable
    public bool collectable; //follow
    public bool interact = false; //dialog
    public bool collect = false; //follow
    public DialogueTriggerHelicopter dialoguetrigger;
    public bool dialogue = false;
    Material[] mat;
    [SerializeField] private GameObject _ferito;
    public AudioSource audio;
    [SerializeField] private AudioClip[] m_Sounds;
    private SceneInfo info;



    // Start is called before the first frame update
    protected override void Start()
    {
        audio = GetComponent<AudioSource>();
        info = GameObject.Find("SceneInfo").GetComponent<SceneInfo>();
        if (GetComponent<SC_NPCFollow>())
            collectable = true;
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
            dialogue = GameObject.Find("DialogueManager").GetComponent<DialogueManagerHelicopter>().dialogue_bool;
            interact = dialogue;
        }
        if (interact == false)
        {
            audio.Stop();
            GameObject.Find("ferito").GetComponent<AudioSource>().Stop();
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().startDialogue == true)
            {
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().startDialogue = false;
            }
        }
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


    public override void Interact(GameObject interacter, Interactable interacted)
    {
        if (((collectable == true && collect == true) && !dialogue) || (collectable == false && !dialogue))
        {
            info.SetPunteggio(info.GetPunteggio() - 10);
            if (info.GetPunteggio() > 0)
            {
                dialoguetrigger.TriggerDialogue();
                int n = Random.Range(1, m_Sounds.Length);
                audio.clip = m_Sounds[n];
                audio.PlayOneShot(audio.clip);
                // move picked sound to index 0 so it's not picked next time
                m_Sounds[n] = m_Sounds[0];
                m_Sounds[0] = audio.clip;
            }
            
            Debug.Log(info.GetPunteggio());
            //do dialogue
        }
        if (collectable == true && collect == false)
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


