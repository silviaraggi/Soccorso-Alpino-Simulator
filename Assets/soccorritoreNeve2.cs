using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class soccorritoreNeve2 : MonoBehaviour
{
    NavMeshAgent agent;
    Transform ToFollow;
    GameObject soccorsoNeve2;
    bool intro;
    bool finale;

    // Start is called before the first frame update
    void Start()
    {
        intro = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro;
        finale = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().finale;
        soccorsoNeve2 = GameObject.Find("SoccorritoreNeve2_cutscene");
        agent = GameObject.Find("SoccorritoreNeve2_gameplay").GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        intro = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro;
        finale = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().finale;
        if (!intro && !finale)
        {

            agent.enabled = true;
            GameObject.Find("SoccorritoreNeve2_gameplay").GetComponent<SC_NPCFollow>().enabled = true;
            ToFollow = GameObject.Find("Player").transform;
            if(GameObject.Find("SoccorritoreNeve2_cutscene").GetComponent<Animator>().GetBool("isStandingUp"))
            GameObject.Find("SoccorritoreNeve2_cutscene").GetComponent<Animator>().SetBool("isStandingUp", false);
            //UpdatePosition();
        }
    }

   /* void UpdatePosition() {
        agent.destination = ToFollow.transform.position;
        Vector3 GoHere = ToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if (agent.velocity.magnitude < 0.15f)
        {
            soccorsoNeve2.GetComponent<Animator>().SetBool("isWalking", false);
            soccorsoNeve2.GetComponent<Animator>().SetBool("isIdle", true);
        }
        else
        {
            soccorsoNeve2.GetComponent<Animator>().SetBool("isWalking", true);
            soccorsoNeve2.GetComponent<Animator>().SetBool("isIdle", false);
        }
    }*/

    public void SetWalking()
    {
        GetComponent<Animator>().SetBool("isWalking", true);
        GetComponent<Animator>().SetBool("isIdle", false);
        GetComponent<Animator>().SetBool("isStandingUp", false);
    }
    public void SetStanding()
    {
        GetComponent<Animator>().SetBool("isWalking", false);
        GetComponent<Animator>().SetBool("isIdle", false);
        GetComponent<Animator>().SetBool("isStandingUp", true);
    }

}
