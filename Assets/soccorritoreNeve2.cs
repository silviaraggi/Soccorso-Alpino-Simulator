using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class soccorritoreNeve2 : MonoBehaviour
{
    NavMeshAgent agent;
    Transform ToFollow;
    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.Find("SoccorritoreNeve2").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ToFollow = GameObject.Find("Player").transform;
        UpdatePosition();
    }

    void UpdatePosition() {
        agent.destination = ToFollow.transform.position;
        Vector3 GoHere = ToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if (agent.velocity.magnitude < 0.15f)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isIdle", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isIdle", false);
        }
    }

}
