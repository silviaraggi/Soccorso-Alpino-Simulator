using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Elicopter _elicopter;
    [SerializeField] private Base_elicopter _base_elicopter;
    [SerializeField] private Elica_dietro _elica_dietro;
    public int cont;
    private Collider collider;

    void Start()
    {
        cont = 0;
        collider = GetComponent<Collider>();
        //_elicopter.Rotate(0);
        //_elica_dietro.Rotate(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        cont = cont + 1;
    }

    private void OnTriggerExit(Collider other)
    {
        /*cont = cont - 1;
        if (cont == 0){
            _elicopter.Rotate(1);
            _elica_dietro.Rotate(1);
            _base_elicopter.Move();
            collider.isTrigger = false;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
    }
}
