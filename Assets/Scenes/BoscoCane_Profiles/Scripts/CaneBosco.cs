using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaneBosco : MonoBehaviour
{
    public int Indizio;
    Transform transformToFollow;
    GameObject player;
    NavMeshAgent agent;
    Transform[] clues;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        clues = GameObject.Find("Indizi").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transformToFollow = clues[Indizio];
        agent.destination = transformToFollow.position;
        Vector3 GoHere = transformToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = rotation;
    }
}
