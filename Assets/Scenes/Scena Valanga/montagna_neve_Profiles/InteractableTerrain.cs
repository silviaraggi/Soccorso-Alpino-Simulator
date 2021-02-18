using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTerrain : LightUpInteractable
{
    public int ClickToDeactivate;
    [SerializeField] ParticleSystem neve = null;
    public AudioClip suono;
    public Terrain[] TuttiTerrain;
    public int[] ClickPerTerrain;
    private int ClickSoFar = 0;
    private int index = 0;
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

    public override void Interact(GameObject interacter, Interactable interacted)
    {
        if (GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().GetisUsingPala())
        {
            if (index < TuttiTerrain.Length&&ClickPerTerrain[index] > 0)
            {
                neve.Play();
                ClickPerTerrain[index]--;
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(suono);
            }
            if (index < TuttiTerrain.Length&&ClickPerTerrain[index] == 0)
            {
                TuttiTerrain[index].enabled = false;
                index++;
                //neve.transform.localPosition = TuttiTerrain[index].gameObject.transform.localPosition;
            }
            if(index==TuttiTerrain.Length)
            {
                GameObject.Find("Disperso_gameplay").GetComponent<Disperso_neve>().SetAnimatable(true);
            }
            /*if (this.gameObject.GetComponent<InteractableTerrain>().ClickToDeactivate == 0)
            {
                if (this.transform.GetChild(0))
                {
                    this.transform.GetChild(0).gameObject.GetComponent<Terrain>().enabled = false;
                    this.transform.GetChild(0).gameObject.GetComponent<TerrainCollider>().enabled = false;
                }
                collect = true;
            }
            else
            {
                
                ClickToDeactivate--;
                neve.Play();
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(suono);
            }*/
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
