using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JeepBosco : MonoBehaviour
{
    private int NumCamera = -1;
    Scene scena;
    GameObject giocatore = null;
    GameObject collega1 = null;
    GameObject collega2 = null;
    GameObject cane = null;
    GameObject maglia = null;
    Camera telecameraGiocatore = null;
    private bool intro;
    private bool finale;
    bool canStart = false;
    GameObject torcia;
    Inventory inventario;
    [SerializeField] GameObject fine;
    // Start is called before the first frame update
    void Start()
    {
        torcia = GameObject.Find("Torcia");
        inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        inventario.Add(torcia.GetComponent<InteractableClue>().GetItem());
        intro = true;
        finale = false;
        scena = gameObject.scene;
        maglia = GameObject.Find("magliasolida");
        cane = GameObject.Find("CaneUnity2");
        giocatore = GameObject.FindGameObjectWithTag("Player");
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");
        telecameraGiocatore = giocatore.transform.Find("Camera").GetComponent<Camera>();
        GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory().Add(GameObject.Find("magliasolida").GetComponent<InteractableClue>().GetItem());
        if (scena.name == "BoscoCane")
            IntroScenaBosco();
    }

    // Update is called once per frame
    void Update()
    {
        if (scena.name == "BoscoCane")
        {
            if (!intro && !finale)
            {
                foreach(Light luce in GameObject.Find("Luci").GetComponentsInChildren<Light>())
                {
                    luce.enabled = false;
                }
                foreach (Renderer daAttivare in collega1.GetComponentsInChildren<Renderer>())
                {
                    daAttivare.enabled = true;
                }
                foreach (Renderer daAttivare in collega2.GetComponentsInChildren<Renderer>())
                {
                    daAttivare.enabled = true;
                }
                if (giocatore.GetComponent<FPSInteractionManager>().GetTorchStatus() == false)
                {
                    GameObject.Find("Collega1").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi2");
                    GameObject.Find("Collega2").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi2");
                }
                else
                {
                    GameObject.Find("Collega2").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi1");
                    GameObject.Find("Collega1").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoColleghi1");
                }
                cane.gameObject.transform.Find("Cane.001").GetComponent<Renderer>().enabled = true;
                cane.gameObject.transform.Find("Cane.002").GetComponent<Renderer>().enabled = true;
                cane.GetComponent<Animator>().enabled = true;
                GetComponent<LightUpInteractable>().SetAnimatable(false);
                giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
                giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
                telecameraGiocatore.enabled = true;
                giocatore.GetComponent<CharacterController>().enabled = true ;
                if (GameObject.Find("Disperso").GetComponent<Disperso>().flag==2&&GameObject.Find("Disperso").GetComponent<Disperso>().GetDispersoState()==Disperso.DispersoState.Found)
                    FineScenaBosco();
            }
        }
    }
    public void FineScenaBosco()
    {
        foreach (Light luce in GameObject.Find("Luci").GetComponentsInChildren<Light>())
        {
            luce.enabled = true;
        }
        Vector3 nuovarotazionejeep = new Vector3(-85.6f, 89.47f, 59.84f);
        this.gameObject.transform.rotation = Quaternion.Euler(nuovarotazionejeep);
        foreach (Renderer daAttivare in collega1.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        foreach (Renderer daAttivare in collega2.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        telecameraGiocatore.enabled = false;
        fine.transform.GetComponent<CompleteMission>().Fine();
        this.GetComponent<Animator>().SetBool("finale", true);
        this.GetComponent<Animator>().SetBool("intro", false);
        GameObject.Find("Cam1").GetComponent<Camera>().enabled = true;
    }
    public void IntroScenaBosco()
    {
        telecameraGiocatore.enabled = false;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        cane.gameObject.transform.Find("Cane.001").GetComponent<Renderer>().enabled = false;
        cane.gameObject.transform.Find("Cane.002").GetComponent<Renderer>().enabled = false;
        cane.GetComponent<Animator>().enabled = false;

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
        GameObject.Find("GestoreCamere").GetComponent<GestoreCamereBosco>().DisableCamera(NumCamera);
    }
    public void LoadMenu()
    {
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Menu");
        Debug.Log("Loading menu...");
    }

}
