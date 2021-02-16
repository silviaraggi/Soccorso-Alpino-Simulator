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
            StartCoroutine(waitForSound());
        }
    }

    IEnumerator waitForSound()
    {
        //Wait Until Sound has finished playing
        while (audio.isPlaying)
        {
            yield return null;
        }
        GetComponent<Animator>().SetBool("isHowl", false);
        GetComponent<Animator>().SetBool("isIdle", true);
        //Auido has finished playing, disable GameObject

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
        if (!(GetComponent<Animator>().GetBool("isHowl") || GetComponent<Animator>().GetBool("isSniff")))
        {
            agent.destination = ToFollow.transform.position;
            Vector3 GoHere = ToFollow.transform.position;
            Vector3 npcPos = gameObject.transform.position;
            Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
            Quaternion rotation = Quaternion.LookRotation(delta);
            if(ToFollow==player)
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        }
        if (agent.velocity.magnitude < 0.15f)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            if(!GetComponent<Animator>().GetBool("isHowl"))
            GetComponent<Animator>().SetBool("isIdle", true);
            if (ToFollow.GetComponent<InteractableClue>() && Vector3.Distance(transform.position, ToFollow.transform.position) <= agent.stoppingDistance)
            {
                if (ToFollow.GetComponent<InteractableClue>().GetInteract() == false)
                {
                    ToFollow.gameObject.GetComponent<InteractableClue>().Interact(this.gameObject, this.GetComponent<InteractableDog>());
                }
                if (ToFollow.GetComponent<Disperso>())
                {
                    ToFollow.GetComponent<Disperso>().SetDispersoState(Disperso.DispersoState.Found);
                    Howl();
                }
            }


        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isIdle", false);
        }
        if (ToFollow.GetComponent<InteractableClue>() && ToFollow.GetComponent<InteractableClue>().GetCollect())
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
        StartCoroutine(PlayAndWaitForAnim(GetComponent<Animator>(),"Sniff"));
        SetTarget(clue);
    }

    public IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName)
    {

        //targetAnim.Play(stateName);
        targetAnim.CrossFadeInFixedTime(stateName, 0.6f);

        //Wait until we enter the current state
        while (!targetAnim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
        {
            yield return null;
        }

        float counter = 1.5f;
        float waitTime = targetAnim.GetCurrentAnimatorStateInfo(0).length;

        //Now, Wait until the current state is done playing
        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Done playing. Do something below!
        GetComponent<Animator>().SetBool("isSniff", false);
        GetComponent<Animator>().SetBool("isWalking", true);

    }
    /*IEnumerator waitForSniff()
    {
        //Wait Until Sound has finished playing
        while (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0))
        {
            yield return null;
        }
        GetComponent<Animator>().SetBool("isSniff", false);
        GetComponent<Animator>().SetBool("isIdle", true);
        //Auido has finished playing, disable GameObject
        
    }*/

}
