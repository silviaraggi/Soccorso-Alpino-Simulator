using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class ItemBosco : Item
{
    public ItemBosco cane;
    public ItemBosco berretto;
    public ItemBosco zaino;
    public ItemBosco guanti;
    public ItemBosco disperso;
    public ItemBosco maglia;
    //bool mouseOver = false;
    public override void Start()
    {
        /*cane = GameObject.FindObjectOfType<CaneBosco>().gameObject;
        disperso = GameObject.FindObjectOfType<Disperso>().gameObject;
        berretto = GameObject.Find("Berretto");
        zaino = GameObject.Find("Zaino");
        guanti = GameObject.Find("Guanti");*/
        // Shader initialShader = Shader.Find("Standard");
        // Shader glowUp = Shader.Find("Toon/Lit Outline");
    }

    public override void OnMouseEnter()
    {
       // mouseOver = true;
        //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
       // meshRenderer.material.shader = glowUp;
    }
    public override void OnMouseExit()
    {
       // mouseOver = false;
       // MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
       // meshRenderer.material.shader = initialShader;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public override void Use()
    {
        /*switch (this.name)
        {
            case "Maglia":
                if(berretto.GetComponent<InteractableClue>().GetCollect()==false)
                cane.GetComponent<CaneBosco>().GetNewClue(berretto);
                break;
            case "Cappello":
                if (zaino.GetComponent<InteractableClue>().GetCollect() == false)
                    cane.GetComponent<CaneBosco>().GetNewClue(zaino);
                break;
            case "Zaino":
                if (guanti.GetComponent<InteractableClue>().GetCollect() == false)
                    cane.GetComponent<CaneBosco>().GetNewClue(guanti);
                break;
            case "Guanti":
                if (disperso.GetComponent<Disperso>().GetDispersoState() == Disperso.DispersoState.Wander)
                    cane.GetComponent<CaneBosco>().GetNewClue(disperso);
                break;
        }*/
    }
}
