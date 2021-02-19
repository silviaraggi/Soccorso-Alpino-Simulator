using UnityEngine;
using UnityEngine.AI;

public class SC_NPCFollow : MonoBehaviour
{
    //Transform that NPC has to follow
    public Transform transformToFollow;
    //NavMesh Agent variable
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
        agent.destination = transformToFollow.position;
        Vector3 GoHere = transformToFollow.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(GoHere.x - npcPos.x, 0.0f, GoHere.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, 0.5f);
        if (agent.velocity == Vector3.zero)
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
    private void ChangeSpeed()
    {
        bool isPlayerWalking = false;
        int whichOne = 0;
        if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
        {
            isPlayerWalking = GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().GetIsWalking();
            whichOne = 1;
        }
        if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
        {
            isPlayerWalking = GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().GetIsWalking();
            whichOne = 2;
        }
        if (isPlayerWalking)
        {
            if (whichOne == 1)
            {
                this.gameObject.GetComponent<NavMeshAgent>().speed = GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().GetWalkSpeed();
                this.gameObject.GetComponent<Animator>().SetFloat("runMultiplier", 1f);
            }
            if (whichOne == 2)
            {
                this.gameObject.GetComponent<NavMeshAgent>().speed = GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().GetWalkSpeed();
                this.gameObject.GetComponent<Animator>().SetFloat("runMultiplier", 1f);
            }
        }
        else
        {
            if (whichOne == 1)
            {
                this.gameObject.GetComponent<NavMeshAgent>().speed = GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().GetRunSpeed();
                this.gameObject.GetComponent<Animator>().SetFloat("runMultiplier", 2f);
            }
            if (whichOne == 2)
            {
                this.gameObject.GetComponent<NavMeshAgent>().speed = GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().GetRunSpeed();
                this.gameObject.GetComponent<Animator>().SetFloat("runMultiplier", 2f);
            }
        }
    }
}