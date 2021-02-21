using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepBaita : MonoBehaviour
{
    int scenario;
    GameObject elicottero;
    GameObject zaino;
    GameObject collega1;
    GameObject collega2;
    GameObject giocatore = null;
    GameObject MainCamera;
    public bool intro;
    bool finale;
    bool isDialogue;
    Material SkyboxGiorno;
    Material SkyboxPome;
    int NumCamera;
    private int dialogoAutomatico =0;
    [SerializeField] private AudioClip[] m_Sounds;
    private AudioSource audio;
    private bool punti;
    private SceneInfo info;
    // Start is called before the first frame update
    void Start()
    {
        isDialogue = GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogue_bool;
        SkyboxGiorno = (Material)Resources.Load("CieloGiorno", typeof(Material));
        SkyboxPome = (Material)Resources.Load("CieloTramonto", typeof(Material));
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        giocatore = GameObject.FindGameObjectWithTag("Player");
        scenario = GameObject.Find("SceneInfo").GetComponent<SceneInfo>().GetScene();
        elicottero = GameObject.Find("elicotterofinal4");
        zaino = GameObject.Find("Zaino");
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");
        audio = collega1.GetComponent<AudioSource>();
        intro = true;
        finale = false;
        if (scenario == 1)
        {
            RenderSettings.skybox = SkyboxGiorno;
            DynamicGI.UpdateEnvironment();
            GameObject.Find("GestoreCamere").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoTelefonata1");
        }
        if (scenario == 2)
        {
            RenderSettings.skybox = SkyboxPome;
            DynamicGI.UpdateEnvironment();
            GameObject.Find("GestoreCamere").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoTelefonata2");
        }

        this.GetComponent<LightUpInteractable>().SetAnimatable(false);
        elicottero.GetComponent<LightUpInteractable>().SetAnimatable(false);
        this.GetComponent<LightUpInteractable>().enabled = false;
        elicottero.GetComponent<LightUpInteractable>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FirstPersonCharacterController>().SetLocked(true);
        Cursor.visible = false;
        info = GameObject.Find("SceneInfo").GetComponent<SceneInfo>();
        punti = info.GetPunti();
    }

    // Update is called once per frame
    void Update()
    {
        isDialogue = GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogue_bool;
        if (!intro&&!finale&&!isDialogue)
        {
            GameObject.Find("CamTitle").GetComponent<AudioListener>().enabled = false;
            giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(true);
            giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
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
                }
                giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().RotateDialogue();
                dialogoAutomatico++;
            }
            if (zaino.GetComponent<LightUpInteractable>().collect == true && collega1.GetComponent<InteractablePerson>().GetCollect() == true && collega2.GetComponent<InteractablePerson>().GetCollect() == true)
            {
                AttivaScena();
                

                if (scenario==1 && elicottero.GetComponent<LightUpInteractable>().GetInteract())
                {
                    FinaleElicottero();

                }
                if (scenario == 2 && this.GetComponent<LightUpInteractable>().GetInteract())
                {
                    FinaleJeep();
                }
            }
        }
    }

    private void AttivaScena()
    {
        if (scenario == 1)
        {
            elicottero.GetComponent<LightUpInteractable>().enabled = true;
            elicottero.GetComponent<LightUpInteractable>().SetAnimatable(true);
            GameObject.Find("Colleghi").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoCollegaElicottero");
            collega1.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoCollegaElicottero");
            collega2.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoCollegaElicottero");
        }
        if (scenario == 2)
        {
            this.GetComponent<LightUpInteractable>().enabled = true;
            this.GetComponent<LightUpInteractable>().SetAnimatable(true);
            GameObject.Find("Colleghi").GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoCollegaJeep");
            collega1.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoCollegaJeep");
            collega2.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("DialogoCollegaJeep");
        }
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
            }
                    giocatore.GetComponent<FirstPersonCharacterControllerSOUND>().RotateDialogue();
                    dialogoAutomatico++;
                }
    }

    private void FinaleElicottero()
    {
        finale = true;
        MainCamera.GetComponent<Camera>().enabled = false;
        //giocatore.GetComponent<Camera>().enabled = false;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        GameObject.Find("CamElicottero").GetComponent<Camera>().enabled = true;
        foreach (Renderer daAttivare in collega1.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        foreach (Renderer daAttivare in collega2.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        elicottero.gameObject.GetComponent<AudioSource>().enabled = true;
    }

    private void FinaleJeep()
    {
        finale = true;
        MainCamera.GetComponent<Camera>().enabled = false;
        GameObject.Find("Portone").GetComponent<Animator>().SetBool("interact", true);
        //giocatore.GetComponent<Camera>().enabled = false;
        GameObject.Find("CamJeep1").GetComponent<Camera>().enabled = true;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        foreach (Renderer daAttivare in collega1.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        foreach (Renderer daAttivare in collega2.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = false;
        }
        this.GetComponent<AudioSource>().enabled = true;
    }

    public void SetCamera(int number)
    {
        NumCamera = number;
    }
    public int GetCamera()
    {
        return NumCamera;
    }

    public void DisableCamera(int NumCamera)
    {

        GameObject.Find("GestoreCamere").GetComponent<GestoreCamereBaita>().DisableCamera(NumCamera);
    }
    public void CaricaScenaCasa()
    {

        GameObject.Find("GestoreScene").GetComponent<GestoreScene>().LoadSceneByID(3);
    }

}
