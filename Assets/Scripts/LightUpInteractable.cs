using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpInteractable : Interactable
{
    public bool animatable;
    public bool collectable;
    public bool interact = false;
    public bool collect = false;
    private Animator _animator;
    Material[] mat;


    // Start is called before the first frame update
    protected override void Start()
    {

        if (GetComponent<Renderer>())
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
            mat = GetComponent<Renderer>().materials;
        }
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


    public override void GlowUp(GameObject changeColor)
    {
        {
            if (mat != null)
            {
                for (int i = 0; i < mat.Length; i++)
                {
                    mat[i].EnableKeyword("_EMISSION");
                    mat[i].SetColor("_EmissionColor", new Vector4(0.15f, 0.30f, 0.30f, 0));
                }
            }
            else
            {
                if (changeColor.transform.GetComponent<Renderer>())
                {
                    mat = changeColor.transform.GetComponent<Renderer>().materials;
                    if (mat != null)
                    {
                        for (int i = 0; i < mat.Length; i++)
                        {
                            mat[i].EnableKeyword("_EMISSION");
                            mat[i].SetColor("_EmissionColor", new Vector4(0.30f, 0.30f, 0.30f, 0));
                        }
                    }
                }
            }
        }
       

    }

    public override void TurnOff()
    {
        if(mat!=null)
        for (int i = 0; i < mat.Length; i++)
        {
            mat[i].DisableKeyword("_EMISSION");
        }

    }

    public override void Interact(GameObject interacter)
    {
        if (!collectable)
        {
            if (_animator.GetBool("interact"))
            {
                _animator.SetBool("interact", false);
                interact = false;
            }
            else
            {
                _animator.SetBool("interact", true);
                interact = true;
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            collect = true;
        }
        TurnOff();
    }

    public override bool GetAnimatable()
    {
        return animatable;
    }
    public override bool GetCollectable()
    {
        return collectable;
    }
    public override bool GetInteract()
    {
        return interact;
    }

    public override bool GetCollect()
    {
        return collect;
    }
    public override void SetAnimatable(bool newvalue)
    {
        animatable = newvalue;
    }
    public override void SetCollectable(bool newvalue)
    {
        collectable = newvalue;
    }
    public override void SetInteract(bool newvalue)
    {
        interact = newvalue;
    }
    public override void SetCollect(bool newvalue)
    {
        collect = newvalue;
    }
}


