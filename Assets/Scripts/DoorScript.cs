using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour { 

    private Animator _animator;
    private bool EnableInteraction = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnableInteraction = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EnableInteraction = false;
        }
    }


    private void Update()
    {

            if (Input.GetMouseButtonDown(0) && EnableInteraction)
            {
            if (_animator.GetBool("open") == false)
            {
                _animator.SetBool("open", true);
            }
            else
                _animator.SetBool("open", false);
        }
    }
}

