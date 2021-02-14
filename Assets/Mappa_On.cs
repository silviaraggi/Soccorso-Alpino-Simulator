using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mappa_On : MonoBehaviour
{
    public GameObject mappa_on;
    // Update is called once per frame


    public void Update()
    {
        if (GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogue_bool == false)
        {
            mappa_on.SetActive(true);
        }
        else
        {
            mappa_on.SetActive(false);
        }
    }
}
