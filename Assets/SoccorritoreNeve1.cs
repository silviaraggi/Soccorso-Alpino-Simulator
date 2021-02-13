using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccorritoreNeve1 : MonoBehaviour
{
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
