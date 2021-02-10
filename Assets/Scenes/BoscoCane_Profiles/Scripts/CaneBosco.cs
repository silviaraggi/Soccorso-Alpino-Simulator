using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CaneBosco : MonoBehaviour
{
    GameObject ToFollow;
    GameObject player;
    NavMeshAgent agent;
    GameObject zaino;
    GameObject disperso;
    GameObject berretto;
    GameObject guanti;
    GameObject previousTarget;
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
        ToFollow = player;
        previousTarget = null;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNewTarget();
    }

    public void Howl()
    {
        if (!audio.isPlaying)
        {
            GetComponent<Animator>().SetBool("isHowl", true);
            GetComponent<Animator>().SetBool("isIdle", false);
            audio.PlayOneShot(ululato, 1f);
        }
    }

    public GameObject GetTarget()
    {
        return ToFollow;
    }

    public void SetTarget(GameObject newTarget)
    {
        ToFollow = newTarget;
    }

    private void CheckNewTarget()
    {
        agent.destination = ToFollow.transform.position;
        Vector3 GoHere = ToFollow.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if (agent.velocity == Vector3.zero)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isIdle", true);
            if (ToFollow.GetComponent<InteractableClue>())
                if (ToFollow.GetComponent<InteractableClue>().GetInteract() == false)
                {
                    ToFollow.gameObject.GetComponent<InteractableClue>().Interact(this.gameObject);
                }
            if (ToFollow.GetComponent<Disperso>())
                ToFollow.GetComponent<Disperso>().SetDispersoState(Disperso.DispersoState.Found);

        }
        else
        {
            if ((GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sniff") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("howl")) && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isSniff", false);
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                GetComponent<Animator>().SetBool("isWalking", true);
                GetComponent<Animator>().SetBool("isIdle", false);
                GetComponent<Animator>().SetBool("isSniff", false);
            }
        }
        if (ToFollow.GetComponent<InteractableClue>()&&ToFollow.GetComponent<InteractableClue>().GetCollect())
        {
            ToFollow = player;
        }
        previousTarget = ToFollow;
    }

    public void GetNewClue(GameObject clue)
    {
        GetComponent<Animator>().SetBool("isWalking", false);
        GetComponent<Animator>().SetBool("isIdle", false);
        GetComponent<Animator>().SetBool("isSniff", true);
        SetTarget(clue);
    }

}
