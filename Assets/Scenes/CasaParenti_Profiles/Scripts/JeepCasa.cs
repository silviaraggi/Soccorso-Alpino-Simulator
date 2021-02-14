using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeepCasa : MonoBehaviour
{
    private int NumCamera = -1;
    GameObject giocatore = null;
    private bool intro;
    private bool canStart = false;
    GameObject maglia;
    Inventory inventario;
    //GameObject cane;
    // Start is called before the first frame update
    void Start()
    {
        inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        intro = true;
        giocatore = GameObject.FindGameObjectWithTag("Player");
        maglia = GameObject.Find("magliasolida");
        maglia.GetComponent<Interactable>().SetCollectable(false);
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
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("GestoreScene").GetComponent<GestoreScene>().LoadSceneByID(4);
    }
}
