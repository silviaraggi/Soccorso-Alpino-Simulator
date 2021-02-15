using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTerrain : LightUpInteractable
{
    public int ClickToDeactivate;
    public override void GlowUp(GameObject changeColor)
    {
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
        if (GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetisUsingPala())
        {
            if (ClickToDeactivate == 0)
            {
                if (gameObject.GetComponent<Renderer>())
                {
                    for (int i = 0; i < gameObject.GetComponentsInChildren<Renderer>().Length; i++)
                    {
                        gameObject.GetComponentsInChildren<Renderer>()[i].enabled = false;
                    }
                    for (int i = 0; i < gameObject.GetComponentsInChildren<Collider>().Length; i++)
                    {
                        gameObject.GetComponentsInChildren<Collider>()[i].enabled = false;
                    }
                }
                collect = true;
            }
            else
            {
                ClickToDeactivate--;
            }
            TurnOff();
        }
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
