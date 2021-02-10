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
    public bool canStart = false;
    GameObject maglia;
    //GameObject cane;
    // Start is called before the first frame update
    void Start()
    {
        intro = true;
        giocatore = GameObject.FindGameObjectWithTag("Player");
        maglia = GameObject.Find("magliasolida");
        maglia.GetComponent<LightUpInteractable>().SetCollectable(false);
        IntroScenaCasa();
    }

    // Update is called once per frame
    void Update()
    {
            if (!intro)
            {
            foreach (Renderer disattiva in GameObject.Find("CaneUnity2").GetComponentsInChildren<Renderer>())
            {
                disattiva.enabled = true;
            }
            foreach (Renderer disattiva in GameObject.Find("Colleghi").GetComponentsInChildren<Renderer>())
            {
                disattiva.enabled = true;
            }
            GameObject.Find("CaneUnity2").GetComponent<CaneCasa>().enabled = true;
            if (!canStart)
                GetComponent<LightUpInteractable>().SetAnimatable(false);
                giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
                giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
                giocatore.GetComponent<CharacterController>().enabled = true;
                if (GameObject.Find("Parenti").GetComponent<InteractablePerson>().GetInteract())
                {
                    maglia.GetComponent<LightUpInteractable>().SetCollectable(true);
                    
                }
            canStart = maglia.GetComponent<LightUpInteractable>().GetCollect();
            if (canStart)
            {
                GetComponent<LightUpInteractable>().SetAnimatable(true);
                if (GetComponent<LightUpInteractable>().GetInteract())
                    FineScenaCasa();
            }
        }
    }
    public void FineScenaCasa() {

        foreach (Renderer disattiva in GameObject.Find("CaneUnity2").GetComponentsInChildren<Renderer>())
        {
            disattiva.enabled = false;
        }
        foreach (Renderer disattiva in GameObject.Find("Colleghi").GetComponentsInChildren<Renderer>())
        {
            disattiva.enabled = false;
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
        foreach (Renderer disattiva in GameObject.Find("CaneUnity2").GetComponentsInChildren<Renderer>())
        {
            disattiva.enabled = false;
        }
        foreach (Renderer disattiva in GameObject.Find("Colleghi").GetComponentsInChildren<Renderer>())
        {
            disattiva.enabled = false;
        }
        giocatore.GetComponent<Camera>().enabled = false;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
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
