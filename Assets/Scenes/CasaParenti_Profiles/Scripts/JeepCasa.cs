using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeepCasa : MonoBehaviour
{
    public AudioClip CarStart;
    private int NumCamera = -1;
    GameObject giocatore = null;
    private bool intro;
    private bool canStart = false;
    GameObject maglia;
    Inventory inventario;
    private int dialogoAutomatico=0;
    GameObject collega1;
    GameObject collega2;
    //GameObject cane;
    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        intro = true;
        giocatore = GameObject.FindGameObjectWithTag("Player");
        maglia = GameObject.Find("magliasolida");
        maglia.GetComponent<Interactable>().SetCollectable(false);
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");

        IntroScenaCasa();
    }

    // Update is called once per frame
    void Update()
    {

        if (!intro)
            {
                if(!canStart)
                GetComponent<LightUpInteractable>().SetAnimatable(false);
            foreach (Renderer daAttivare in GameObject.Find("Colleghi").GetComponentsInChildren<Renderer>())
            {
                daAttivare.enabled = true;
            }
            foreach (Renderer daAttivare in GameObject.Find("CaneUnity2").GetComponentsInChildren<Renderer>())
            {
                daAttivare.enabled = true;
            }
            GameObject.Find("CaneUnity2").GetComponent<CaneCasa>().enabled = true;
            giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
                giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
                giocatore.GetComponent<CharacterController>().enabled = true;
            if (dialogoAutomatico == 0)
            {
                giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().startDialogue = true;
                if (collega2.GetComponent<InteractablePerson>().GetInteract() == false)
                {
                    collega2.GetComponent<DialogueTrigger>().TriggerDialogue();
                    collega2.GetComponent<AudioSource>().PlayOneShot(collega2.GetComponent<InteractablePerson>().dialogo, 1f);
                }
                giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().RotateDialogue();
                dialogoAutomatico++;

            }

            if (GameObject.Find("Parenti").GetComponent<InteractablePerson>().GetInteract())
                {
                    maglia.GetComponent<Interactable>().SetCollectable(true);
                    GameObject.Find("Colleghi").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi2");
                    
            }
            canStart = maglia.GetComponent<Interactable>().GetCollect();
            if (canStart)
            {
                GameObject.Find("Parenti").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoParenti2");
                GameObject.Find("Colleghi").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi3");
                collega1.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi3");
                collega2.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi3");
                if (Vector3.Distance(giocatore.transform.position, collega1.transform.position) < 3f)
                {
                    if (dialogoAutomatico == 1)
                    {
                        giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().collega = collega1;
                        giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().startDialogue = true;
                        if (collega1.GetComponent<InteractablePerson>().GetInteract() == false)
                        {
                            collega1.GetComponent<DialogueTrigger>().TriggerDialogue();
                            collega1.GetComponent<AudioSource>().PlayOneShot(collega1.GetComponent<InteractablePerson>().dialogo, 1f);
                        }
                        giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().RotateDialogue();
                        dialogoAutomatico++;
                    }
                }
                GetComponent<LightUpInteractable>().SetAnimatable(true);
                if (GetComponent<LightUpInteractable>().GetInteract())
                    FineScenaCasa();
            }
        }
    }
    public void FineScenaCasa()
    {

        foreach (Renderer daAttivare in GameObject.Find("Colleghi").GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        foreach (Renderer daAttivare in GameObject.Find("CaneUnity2").GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        if (!(GameObject.Find("Cam2").GetComponent<Camera>().enabled||GameObject.Find("Cam3").GetComponent<Camera>().enabled))
        GameObject.Find("Cam1").GetComponent<Camera>().enabled = true;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
        GameObject.Find("Cube").GetComponent<BoxCollider>().enabled = false;
        if(!gameObject.GetComponent<AudioSource>().isPlaying)
        gameObject.GetComponent<AudioSource>().PlayOneShot(CarStart);
    }
    public void IntroScenaCasa()
    {
        giocatore.GetComponent<Camera>().enabled = false;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        foreach (Renderer daAttivare in GameObject.Find("Colleghi").GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        foreach (Renderer daAttivare in GameObject.Find("CaneUnity2").GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
    }

    public void SetCamera(int number)
    {
        NumCamera = number;
    }
    public int GetCamera()
    {
        return NumCamera;
    }

    public void SetIntro()
    {
        GetComponent<Animator>().SetBool("intro", false);
        intro = false;
    }

    public void DisableCamera(int NumCamera)
    {
        GameObject.Find("GestoreCamere").GetComponent<GestoreCamereCasa>().DisableCamera(NumCamera);
    }
    public void CaricaScenaBosco()
    {
        GameObject.Find("GestoreScene").GetComponent<GestoreScene>().LoadSceneByID(4);
    }
}
