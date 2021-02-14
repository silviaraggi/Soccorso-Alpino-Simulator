using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBarella : MonoBehaviour
{
    [SerializeField]  GameObject _ferito;
    private Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_ferito.GetComponent<BoxCollider>() == other)
            GameObject.Find("Player").GetComponent<FPSInteractionManagerHelicopter>().Drop();
    }

    
}
