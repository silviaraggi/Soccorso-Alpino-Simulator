﻿using System.Collections;
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
    private GameObject _firstAidKit;
    private GameObject _ferito;
    [SerializeField] GameObject _NPC;
    [SerializeField] GameObject _copter;

    private void Start()
    {
        _child = this.gameObject.transform.GetChild(7);
        _animator = GetComponent<Animator>();
        getOut = false;
        intro = true;
        _firstAidKit = GameObject.Find("first-aid-kit");
        _firstAidKit.GetComponent<LightUpInteractableHelicopter>().SetCollectable(false);
        _ferito = GameObject.Find("ferito");
        _ferito.GetComponent<LightUpInteractableHelicopter>().SetCollectable(false);
        _NPC.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
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

            _NPC.transform.GetComponent<SC_NPCFollow>().enabled = true;
            _animator.SetBool("getOut", true);
            getOut = true;

            _firstAidKit.GetComponent<LightUpInteractableHelicopter>().SetCollectable(true);
        }
        if (_copter.GetComponent<Interactable>() != null)
        {
            if (_copter.GetComponent<Interactable>().GetInteract() == true)
            {
                FineScenaHelicopter();
                _animator.SetBool("fine", true);
            }
        }
    }
    
    public void IntroScenaHelicopter()
    {
        _child.GetChild(0).GetComponent<Camera>().enabled = false;
        _child.GetComponent<CharacterController>().enabled = false;
        _child.GetComponent<FPSInteractionManagerHelicopter>().SetUnlocked(false);
        _child.GetComponent<FPSInteractionManagerHelicopter>().SetUIVisible(false);
    }

    public void FineScenaHelicopter()
    {
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


