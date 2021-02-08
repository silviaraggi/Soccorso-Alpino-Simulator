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
        transformToFollow = player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = transformToFollow.position;
        if (transformToFollow != player.transform)
            transformToFollow.gameObject.GetComponent<BoxCollider>().enabled = true;
        Vector3 GoHere = transformToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if ((transformToFollow.gameObject.GetComponent<InteractableClue>() && transformToFollow.gameObject.GetComponent<InteractableClue>().GetInteract() == true) || (transformToFollow.gameObject.GetComponent<Disperso>() && transformToFollow.gameObject.GetComponent<Disperso>().GetDispersoState() == Disperso.DispersoState.Found))
            GetComponent<Animator>().SetBool("isIdle", true);
            GetComponent<Animator>().SetBool("isWalking", false);
        if (transformToFollow.gameObject.GetComponent<InteractableClue>() && transformToFollow.gameObject.GetComponent<InteractableClue>().GetInteract() == true && transformToFollow.gameObject.GetComponent<InteractableClue>().GetCollect() == true)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isSniff", false);
            transformToFollow = player.transform;
        }
    }

    public void Howl()
    {
        if (!audio.isPlaying)
        {
            GetComponent<Animator>().SetBool("isHowl", true);
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
        else if (transformToFollow == player.transform)
            {
                GetComponent<Animator>().SetBool("isIdle", true);
            }
    }

}
