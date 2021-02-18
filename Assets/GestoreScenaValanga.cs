using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityStandardAssets.Characters.FirstPerson;

public class GestoreScenaValanga : MonoBehaviour
{
    private GameObject Soccorritore1;
    private GameObject Soccorritore2_CS;
    private GameObject Soccorritore2_GP;
    private GameObject Disperso;
    private GameObject player;
    public bool intro;
    public bool finale;
    bool inventarioStart;
    public Inventory inventario;
    private GameObject sonda;
    private GameObject Buca1;
    private GameObject Buca2;
    private GameObject Buca3;
    private GameObject Buca4;
    private GameObject Buca5;
    // Start is called before the first frame update
    void Start()
    {
        inventarioStart = false;
        intro = true;
        finale = false;
        player = GameObject.Find("Player");
        sonda = GameObject.Find("Sonda_aperta");
        /*inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        inventario.Add(GameObject.Find("ARTVA").GetComponent<InteractableClue>().GetItem());
        inventario.Add(GameObject.Find("Sonda_aperta").GetComponent<InteractableClue>().GetItem());
        inventario.Add(GameObject.Find("Pala").GetComponent<InteractableClue>().GetItem());*/
        //Timeline = GameObject.Find("Timeline");
        Disperso = GameObject.Find("Disperso_gameplay");
        Soccorritore1 = GameObject.Find("SoccorritoreNeve1");
        Soccorritore2_CS = GameObject.Find("SoccorritoreNeve2_cutscene");
        Soccorritore2_GP = GameObject.Find("SoccorritoreNeve2_gameplay");
        Buca1 = GameObject.Find("Scavo");
        Buca2 = GameObject.Find("Scavo2");
        Buca3 = GameObject.Find("Scavo3");
        Buca4 = GameObject.Find("Scavo4");
        Buca5 = GameObject.Find("Scavo5");
        foreach ( Renderer daDisattivare in Soccorritore2_GP.GetComponentsInChildren<Renderer>()){
            daDisattivare.enabled = false;
        }
        foreach (Renderer daDisattivare in Soccorritore2_CS.GetComponentsInChildren<Renderer>())
        {
            daDisattivare.enabled = true;
        }
        //director = Timeline.GetComponent<PlayableDirector>();
        foreach (Renderer daAttivare in Soccorritore1.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        inventario = GameObject.Find("Strumenti").GetComponent<InventoryUI>().GetInventory();
        if (!inventarioStart)
        {
            inventario.Add(GameObject.Find("ARTVA").GetComponent<InteractableClue>().GetItem());
            inventario.Add(GameObject.Find("Sonda_aperta").GetComponent<InteractableClue>().GetItem());
            inventario.Add(GameObject.Find("Pala").GetComponent<InteractableClue>().GetItem());
            inventarioStart = true;
        }
        if (!intro && !finale)
        {
            player.GetComponent<FirstPersonCharacterControllerSOUND>().isLocked = false;
            foreach (Renderer daDisattivare in Soccorritore2_GP.GetComponentsInChildren<Renderer>())
            {
                daDisattivare.enabled = true;
            }
            foreach (Renderer daDisattivare in Soccorritore2_CS.GetComponentsInChildren<Renderer>())
            {
                daDisattivare.enabled = false;
            }
            foreach (Renderer daAttivare in Soccorritore1.GetComponentsInChildren<Renderer>())
            {
                daAttivare.enabled = false;
            }
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
            Soccorritore2_GP.GetComponent<SC_NPCFollow>().enabled = true;
            Soccorritore2_GP.GetComponent<NavMeshAgent>().enabled = true;
            Soccorritore2_GP.GetComponent<soccorritoreNeve2>().enabled = true;
            Soccorritore2_GP.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("Dialogo1");
            if (Disperso.GetComponent<Disperso_neve>().GetArtvaActive())
                Soccorritore2_GP.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("Dialogo2");
            if (Disperso.GetComponent<Disperso_neve>().GetCanUseSonda())
                Soccorritore2_GP.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("Dialogo3");
            if (sonda.GetComponent<Renderer>().enabled)
            {
                Soccorritore2_GP.GetComponent<DialogueTrigger>().dialogue = GameObject.Find("Dialogo4");
            }

        }
        if (GameObject.Find("ScavoPala")&&GameObject.Find("ScavoPala").GetComponent<InteractableTerrain>().ClickPerTerrain[(GameObject.Find("ScavoPala").GetComponent<InteractableTerrain>().TuttiTerrain.Length) - 1] == 0)
        {
            GameObject.Find("ScavoPala").SetActive(false);
        }
        if (finale)
        {
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("CamFinale").GetComponent<Camera>().enabled = true;
            GameObject.Find("CompleteMission").GetComponent<CompleteMission>().Fine();
            GameObject.Find("elicotterofinal4").GetComponent<elicotteroneve>().EnableElicottero();
        }
        if (Disperso.GetComponent<Disperso_neve>().flag == 2)
            finale = true;
    }
}
