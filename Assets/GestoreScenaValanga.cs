using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
public class GestoreScenaValanga : MonoBehaviour
{
    private GameObject Soccorritore1;
    private GameObject Soccorritore2;
    private GameObject Disperso;
    private GameObject Timeline;
    public PlayableDirector director;
    private GameObject player;
    public bool play;
    // Start is called before the first frame update
    void Start()
    {
        play = false;
        player = GameObject.Find("Player");
        Timeline = GameObject.Find("Timeline");
        Disperso = GameObject.Find("Disperso");
        Soccorritore1 = GameObject.Find("SoccorritoreNeve1");
        Soccorritore2 = GameObject.Find("SoccorritoreNeve2");
        director = Timeline.GetComponent<PlayableDirector>();
        foreach (Renderer daAttivare in Soccorritore1.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = true;
        }
        Soccorritore2.transform.position = new Vector3(72.22f, 36.43f, 134.61f);
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing)
            play = true;
        if (play)
        {

            foreach (Renderer daAttivare in Soccorritore1.GetComponentsInChildren<Renderer>())
            {
                daAttivare.enabled = false;
            }
            GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;
            Soccorritore2.GetComponent<SC_NPCFollow>().enabled = true;
            Soccorritore2.GetComponent<NavMeshAgent>().enabled = true;
            Soccorritore2.GetComponent<soccorritoreNeve2>().enabled = true;
            //do stuff
        }

    }
}
