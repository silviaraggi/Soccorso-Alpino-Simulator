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
    int NumCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        giocatore = GameObject.FindGameObjectWithTag("Player");
        //scenario = GameObject.Find("SceneInfo").GetComponent<SceneInfo>().GetScene();
        scenario = 2;
        elicottero = GameObject.Find("elicotterofinal4");
        zaino = GameObject.Find("Zaino");
        collega1 = GameObject.Find("Collega1");
        collega2 = GameObject.Find("Collega2");
        intro = false;
        finale = false;
        if (scenario == 1) //elicottero
        this.GetComponent<LightUpInteractable>().SetAnimatable(false);
        elicottero.GetComponent<LightUpInteractable>().SetAnimatable(false);
        this.GetComponent<LightUpInteractable>().enabled = false;
        elicottero.GetComponent<LightUpInteractable>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!intro && !finale)
        {
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
        giocatore.GetComponent<Camera>().enabled = false;
        giocatore.GetComponent<CharacterController>().enabled = false;
        giocatore.GetComponent<FPSInteractionManager>().SetUnlocked(false);
        giocatore.GetComponent<FPSInteractionManager>().SetUIVisible(false);
        GameObject.Find("CamElicottero").GetComponent<Camera>().enabled = true;
    }

    private void FinaleJeep()
    {
        finale = true;
        MainCamera.GetComponent<Camera>().enabled = false;
        //GameObject.Find("Portone").GetComponent<Animator>().SetBool("interact", true);
        giocatore.GetComponent<Camera>().enabled = false;
        GameObject.Find("CamJeep1").GetComponent<Camera>().enabled = true;
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

    public void DisableCamera(int NumCamera)
    {
        GameObject.Find("GestoreCamere").GetComponent<GestoreCamereBaita>().DisableCamera(NumCamera);
    }
    public void CaricaScenaCasa()
    {
        //To be implemented
    }

}
