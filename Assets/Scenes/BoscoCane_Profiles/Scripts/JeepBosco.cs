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
    bool torciaAdded;
    [SerializeField] GameObject fine;
    public AudioClip CarStart;
    public AudioClip CarStop;
    private int dialogoAutomatico = 0;
    [SerializeField] private AudioClip[] m_Sounds;
    private AudioSource audio;
    private bool punti;
    private SceneInfo info;
    // Start is called before the first frame update
    void Start()
    {
        torciaAdded = false;
        torcia = GameObject.Find("Torcia");
        intro = true;
        finale = false;
        scena = gameObject.scene;
        maglia = GameObject.Find("magliasolida");
        cane = GameObject.Find("CaneUnity2");
        giocatore = GameObject.FindGameObjectWithTag("Player");
        inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");
        audio = collega1.GetComponent<AudioSource>();
        telecameraGiocatore = giocatore.transform.Find("Camera").GetComponent<Camera>();
        info = GameObject.Find("SceneInfo").GetComponent<SceneInfo>();
        punti = info.GetPunti();
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
                if (dialogoAutomatico == 0)
                {
                    giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().startDialogue = true;
                    if (collega1.GetComponent<InteractablePerson>().GetInteract() == false && punti == false)
                    {
                        collega1.GetComponent<DialogueTrigger>().TriggerDialogue();
                        int n = UnityEngine.Random.Range(1, m_Sounds.Length);
                        audio.clip = m_Sounds[n];
                        // move picked sound to index 0 so it's not picked next time
                        m_Sounds[n] = m_Sounds[0];
                        m_Sounds[0] = audio.clip;
                        audio.PlayOneShot(audio.clip, 1f);
                        giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().RotateDialogue();
                    }
                    
                    dialogoAutomatico++;
                }
                if (!torciaAdded)
                {
                    inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
                    inventario.Add(torcia.GetComponent<InteractableClue>().GetItem());
                    GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory().Add(GameObject.Find("magliasolida").GetComponent<InteractableClue>().GetItem());
                    torciaAdded = true;
                }
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
                    if (dialogoAutomatico == 1)
                    {
                        giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().startDialogue = true;
                        if (collega1.GetComponent<InteractablePerson>().GetInteract() == false && punti == false)
                        {
                            collega1.GetComponent<DialogueTrigger>().TriggerDialogue();
                            int n = UnityEngine.Random.Range(1, m_Sounds.Length);
                            audio.clip = m_Sounds[n];
                            // move picked sound to index 0 so it's not picked next time
                            m_Sounds[n] = m_Sounds[0];
                            m_Sounds[0] = audio.clip;
                            audio.PlayOneShot(audio.clip, 1f);
                            giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().RotateDialogue();
                        }

                        dialogoAutomatico++;
                    }
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
        if(!this.gameObject.GetComponent<AudioSource>().isPlaying)
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(CarStart);
    }
    public void IntroScenaBosco()
    {
        telecameraGiocatore.enabled = false;
        //giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        cane.gameObject.transform.Find("Cane.001").GetComponent<Renderer>().enabled = false;
        cane.gameObject.transform.Find("Cane.002").GetComponent<Renderer>().enabled = false;
        cane.GetComponent<Animator>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(CarStop);
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
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().Reload();
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Menu");
        Debug.Log("Loading menu...");
    }

}
