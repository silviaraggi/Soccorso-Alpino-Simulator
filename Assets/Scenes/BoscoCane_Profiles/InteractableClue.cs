using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableClue : Interactable
{
    public bool animatable;
    public bool collectable;
    public bool interact = false; //found
    public bool collect = false;
    Material[] mat;


    // Start is called before the first frame update
    protected override void Start()
    {

            collectable = true;
            animatable = true;
    }


    public override void GlowUp(GameObject changeColor)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.GetComponent<Renderer>())
            {
                if (child.gameObject.GetComponent<Renderer>().materials.Length > 0)

                    for (int i = 0; i < child.gameObject.GetComponent<Renderer>().materials.Length; i++)
                    {
                        child.gameObject.GetComponent<Renderer>().materials[i].EnableKeyword("_EMISSION");
                        child.gameObject.GetComponent<Renderer>().materials[i].SetColor("_EmissionColor", new Vector4(0.15f, 0.30f, 0.30f, 0));
                    }
            }

        }

    }

    public override void TurnOff()

    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.GetComponent<Renderer>())
            {
                if (child.gameObject.GetComponent<Renderer>().materials.Length > 0)

                    for (int i = 0; i < child.gameObject.GetComponent<Renderer>().materials.Length; i++)
                    {
                        child.gameObject.GetComponent<Renderer>().materials[i].DisableKeyword("_EMISSION");
                    }
            }
        }

    }

    public override void Interact(GameObject interacter)
    {
        if (interacter.GetComponent<CaneBosco>()&&!interact)
        {
            interact = true;
            interacter.GetComponent<CaneBosco>().Howl();
            //abilita sistema visibilità oggetto
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            collect = true;
            //disabilita sistema visibilità oggetto
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


