﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Windows.Input;
public class InteractableDog : Interactable
{
    public bool animatable;
    public bool collectable;
    public bool interact = false; //found
    public bool collect = false;
    Material[] mat;

    private float time = 0.0f;
    public float interpolationPeriod = 6f;

    // Start is called before the first frame update
    protected override void Start()
    {

            collectable = false;
            animatable = true;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            this.SetAnimatable(true);
            // execute block of code here
        }
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

    public override void Interact(GameObject interacter, Interactable interacted)
    {
             interact = true;
            //abilita sistema visibilità oggetto
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


