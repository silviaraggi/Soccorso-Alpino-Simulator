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
    bool intro;
    bool finale;
    Material SkyboxGiorno;
    Material SkyboxPome;
    int NumCamera;
    // Start is called before the first frame update
    void Start()
    {
        SkyboxGiorno = (Material)Resources.Load("CieloGiorno", typeof(Material));
        SkyboxPome = (Material)Resources.Load("CieloTramonto", typeof(Material));
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        giocatore = GameObject.FindGameObjectWithTag("Player");
        scenario = GameObject.Find("SceneInfo").GetComponent<SceneInfo>().GetScene();
        elicottero = GameObject.Find("elicotterofinal4");
        zaino = GameObject.Find("Zaino");
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");
        intro = false;
        finale = false;
        if (scenario == 1)
        {
            RenderSettings.skybox = SkyboxGiorno;
            DynamicGI.UpdateEnvironment();
        }
        if (scenario == 2)
        {
            RenderSettings.skybox = SkyboxPome;
            DynamicGI.UpdateEnvironment();
        }

        this.GetComponent<LightUpInteractable>().SetAnimatable(false);
        elicottero.GetComponent<LightUpInteractable>().SetAnimatable(false);
        this.GetComponent<LightUpInteractable>().enabled = false;
        elicottero.GetComponent<LightUpInteractable>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!intro && !finale)
        {
            giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(true);
            giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(true);
            if (zaino.GetComponent<LightUpInteractable>().collect == true && collega1.GetComponent<InteractablePerson>().collect == true && collega2.GetComponent<InteractablePerson>().collect == true)
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
        }
        if (scenario == 2)
        {
            this.GetComponent<LightUpInteractable>().enabled = true;
            this.GetComponent<LightUpInteractable>().SetAnimatable(true);
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
        collega1.GetComponent<Renderer>().enabled = false;
        collega2.GetComponent<Renderer>().enabled = false;
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
        collega1.GetComponent<Renderer>().enabled = false;
        collega2.GetComponent<Renderer>().enabled = false;
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
