using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMaglia : MonoBehaviour
{
    public LightUpInteractable maglia;
    public bool collectMagliaIsTrue;
    // Start is called before the first frame update
    void Start()
    {
        collectMagliaIsTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (maglia.collect)
        {
            collectMagliaIsTrue = true;
        }
    }
       
    
}
