using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpInteractable : Interactable
{
    bool animatable;
    bool collectable;
    bool interact = false;
    bool collect = false;
    private Animator _animator;
    Material mat;
    // Start is called before the first frame update
    protected override void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (GetComponent<Animator>() == null)
        {
            collectable = true;
        }
        else
        {
            animatable = true;
            _animator = GetComponent<Animator>();
            interact = GetComponent<Animator>().GetBool("interact");
        }
    }

 
    public override void GlowUp(GameObject interacter)
    {
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", new Vector4(0.15f, 0.15f, 0.15f, 0));
        
    }
    public override void TurnOff()
    {
        mat.DisableKeyword("_EMISSION");
    }

    public override void Interact(GameObject interacter)
    {
        if (_animator.GetBool("interact"))
        {
            _animator.SetBool("interact", false);
        }
        else
        {
            _animator.SetBool("interact", true);
        }
    }

    /*protected override void Update()
    {
     
    }*/


}