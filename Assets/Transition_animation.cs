using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_animation : MonoBehaviour
{
    public Animator animation_transition;
    //public GameObject transition;
   
  

    public void entry_transition()
    {
        animation_transition.SetBool("end", true);
    }

    public void exit_transition()
    {
        animation_transition.SetBool("end", false);

    }


}
