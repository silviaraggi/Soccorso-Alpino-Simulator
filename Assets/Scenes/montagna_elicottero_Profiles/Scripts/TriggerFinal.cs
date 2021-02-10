using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinal : MonoBehaviour
{
    [SerializeField] private GameObject _elicopter;
    [SerializeField] private GameObject _barella;
    private Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == _barella.GetComponent<BoxCollider>() && _barella.transform.GetChildCount()==1)
        {
            transform.GetComponent<LightUpInteractable>().enabled = true;
            transform.GetComponent<LightUpInteractable>().SetCollectable(false);
            transform.GetComponent<LightUpInteractable>().SetAnimatable(true);
        }
    }
}

