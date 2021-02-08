using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CaneBosco : MonoBehaviour
{
    Transform transformToFollow;
    GameObject player;
    NavMeshAgent agent;
    GameObject zaino;
    GameObject disperso;
    GameObject berretto;
    GameObject guanti;
    public AudioClip ululato;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
        if(transformToFollow!=player.transform)
        transformToFollow.gameObject.GetComponent<BoxCollider>().enabled = true;
        Vector3 GoHere = transformToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if (transformToFollow.gameObject.GetComponent<InteractableClue>() && transformToFollow.gameObject.GetComponent<InteractableClue>().GetInteract() == true&& transformToFollow.gameObject.GetComponent<InteractableClue>().GetCollect() == true)
            transformToFollow = player.transform;
    }

    public void Howl()
    {
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(ululato, 1f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(transformToFollow.gameObject.GetComponent<InteractableClue>())
        if(transformToFollow.gameObject.GetComponent<InteractableClue>().GetInteract() == false)
        {
            transformToFollow.gameObject.GetComponent<InteractableClue>().Interact(this.gameObject);
        }
    }

}
