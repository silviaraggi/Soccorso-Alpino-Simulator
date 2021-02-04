using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaneCasa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSit(int valore)
    {
        if(valore==1)
        GetComponent<Animator>().SetBool("Sit", true);
        else
            GetComponent<Animator>().SetBool("Sit", false);
    }
    public void SetVisible(bool value)
    {
        GameObject.Find("Cane.001").GetComponent<SkinnedMeshRenderer>().enabled = value;
        GameObject.Find("Cane.002").GetComponent<SkinnedMeshRenderer>().enabled = value;
    }
}
