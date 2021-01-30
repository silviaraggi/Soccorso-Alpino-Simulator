using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneFineCasa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Jeep").GetComponent<LightUpInteractable>().GetInteract())
        {
            this.GetComponent<Animator>().SetBool("active", true);
            this.GetComponent<Camera>().enabled = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled=false;
        }
    }
}
