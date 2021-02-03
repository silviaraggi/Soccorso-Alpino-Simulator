using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Base_elicopter : MonoBehaviour
{

    private Transform _child;
    private Animator _animator;
    public bool getOut;
    private int NumCamera = -1;
    private bool intro;

    private void Start()
    {
        _child = this.gameObject.transform.GetChild(7);
        _animator = GetComponent<Animator>();
        getOut = false;
        intro = true;
        GameObject.Find("first-aid-kit").GetComponent<LightUpInteractable>().SetCollectable(false);
    }

    private void Update()
    {
        if (!intro)
        {
            _child.GetComponent<FPSInteractionManagerHelicopter>().SetUnlocked(true);
            _child.GetComponent<FPSInteractionManagerHelicopter>().SetUIVisible(true);
            _child.GetChild(0).GetComponent<Camera>().enabled = true;
            _child.GetComponent<CharacterController>().enabled = true;


        }
        if (_child.parent != null && Vector3.Distance(_child.position, transform.position) > 5f)
        {
            
            _child.parent = null;
            if (_animator == null)
                return;

            _animator.SetBool("getOut", true);
            getOut = true;
            GameObject.Find("first-aid-kit").GetComponent<LightUpInteractable>().SetCollectable(true);
        }
    }



    
    public void IntroScenaHelicopter()
    {
        _child.GetChild(0).GetComponent<Camera>().enabled = false;
        _child.GetComponent<CharacterController>().enabled = false;
        _child.GetComponent<FPSInteractionManagerHelicopter>().SetUnlocked(false);
        _child.GetComponent<FPSInteractionManagerHelicopter>().SetUIVisible(false);
    }

    public void SetCamera(int number)
    {
        NumCamera = number;
 
    }
    public int GetCamera()
    {
        return NumCamera;
        
    }

    public void SetIntro()
    {
        intro = false;
    }

    public void DisableCamera(int NumCamera)
    {
        _child.GetComponent<GestoreCamereHelicopter>().DisableCamera(NumCamera);
    }
    
}


