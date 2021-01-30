using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Base_elicopter : MonoBehaviour
{

    private Transform _child;
    private Animator _animator;

    private void Start()
    {
        _child = this.gameObject.transform.GetChild(6);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_child.parent != null && Vector3.Distance(_child.position, transform.position) > 3f)
        {
            
            _child.parent = null;
            move();
        }
    }

    public void move()
    {
        if (_animator == null)
            return;

        _animator.SetBool("getOut", true);
    }



}
