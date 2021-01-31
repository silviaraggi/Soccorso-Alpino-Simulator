using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Elicopter _elicopter;
    public int cont;
    private Collider _collider;
    private Animator _animator;

    void Start()
    {
        cont = 1;
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        cont = cont + 1;
        if (cont == 5)
            cont = cont - 1;
    }

    private void OnTriggerExit(Collider other)
    {
        cont = cont - 1;
        if (cont == 0){
            if (_animator == null)
                return;

            _animator.SetBool("free", true);
        }
        else
        {
            if (_animator == null)
                return;

            _animator.SetBool("free", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
    }
}
