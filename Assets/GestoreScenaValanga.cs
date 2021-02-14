using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
public class GestoreScenaValanga : MonoBehaviour
{
    private GameObject Soccorritore1;
    private GameObject Soccorritore2_CS;
    private GameObject Soccorritore2_GP;
    private GameObject Disperso;
    private GameObject player;
    public bool intro;
    public bool finale;
    // Start is called before the first frame update
    void Start()
    {
        intro = true;
        finale = false;
        player = GameObject.Find("Player");
        //Timeline = GameObject.Find("Timeline");
        Disperso = GameObject.Find("Disperso");
        Soccorritore1 = GameObject.Find("SoccorritoreNeve1");
        Soccorritore2_CS = GameObject.Find("SoccorritoreNeve2_cutscene");
        Soccorritore2_GP = GameObject.Find("SoccorritoreNeve2_gameplay");
        foreach( Renderer daDisattivare in Soccorritore2_GP.GetComponentsInChildren<Renderer>()){
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
        if (!intro && !finale)
        {
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
        }
            //do stuff
       // }

    }
}
