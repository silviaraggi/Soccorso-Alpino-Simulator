using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeepCasa : MonoBehaviour
{
    private int NumCamera = -1;
    Scene scena;
    GameObject giocatore = null;
    private bool intro;
    bool canStart = false;
    //GameObject cane;
    // Start is called before the first frame update
    void Start()
    {
        intro = true;
        scena = gameObject.scene;
        giocatore = GameObject.FindGameObjectWithTag("Player");
        //cane = GameObject.Find("CaneUnity2");
        GameObject.Find("magliasolida").GetComponent<LightUpInteractable>().SetCollectable(false);
        if (scena.name == "CasaParenti")
            IntroScenaCasa();
    }

    // Update is called once per frame
    void Update()
    {
        if (scena.name == "CasaParenti")
        {
            if (!intro)
            {
                GetComponent<LightUpInteractable>().SetAnimatable(false);
                giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
                giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
                //cane.GetComponent<CaneCasa>().SetVisible(true);
                //cane.GetComponent<Animator>().enabled = true;
                GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
                giocatore.GetComponent<CharacterController>().enabled = true;
                if (GameObject.Find("Parenti").GetComponent<Interactable>().GetInteract())
                {
                    GameObject.Find("magliasolida").GetComponent<LightUpInteractable>().SetCollectable(true);
                    canStart = GameObject.Find("magliasolida").GetComponent<LightUpInteractable>().GetCollect();
                    if (canStart)
                    {
                        GetComponent<LightUpInteractable>().SetAnimatable(true);
                        if (GetComponent<LightUpInteractable>().GetInteract())
                            FineScenaCasa();
                    }
                }
            }
        }
    }
    public void FineScenaCasa()
    {
        //cane.GetComponent<CaneCasa>().SetVisible(false);
        if(!(GameObject.Find("Cam2").GetComponent<Camera>().enabled||GameObject.Find("Cam3").GetComponent<Camera>().enabled))
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
        //cane.GetComponent<CaneCasa>().SetVisible(false);
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
        GameObject.Find("GestoreScene").GetComponent<GestoreScene>().LoadSceneByID(1);
    }
}
