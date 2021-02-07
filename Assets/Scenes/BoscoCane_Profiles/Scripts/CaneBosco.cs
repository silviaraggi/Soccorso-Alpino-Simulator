using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaneBosco : MonoBehaviour
{
    Transform transformToFollow;
    GameObject player;
    NavMeshAgent agent;
    GameObject zaino;
    GameObject disperso;
    GameObject berretto;
    GameObject guanti;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        zaino = GameObject.Find("Zaino");
        berretto = GameObject.Find("Berretto");
        guanti = GameObject.Find("Guanti");
        transformToFollow = zaino.transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = transformToFollow.position;
        Vector3 GoHere = transformToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if (Vector3.Distance(agent.destination, transformToFollow.position) <= agent.stoppingDistance&&transformToFollow.gameObject.GetComponent<InteractableClue>())
        {
            transformToFollow.gameObject.GetComponent<InteractableClue>().Interact(this.gameObject);
        }
    }
    public void Howl()
    {
        //tbd
        print("Howl");
    }

}
