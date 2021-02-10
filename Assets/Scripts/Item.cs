using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name="New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public int ID;

    
    //bool mouseOver = false;
    public void Start()
    {
       // Shader initialShader = Shader.Find("Standard");
       // Shader glowUp = Shader.Find("Toon/Lit Outline");
    }

    public void OnMouseEnter()
    {
       // mouseOver = true;
        //MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
       // meshRenderer.material.shader = glowUp;
    }
    public void OnMouseExit()
    {
       // mouseOver = false;
       // MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
       // meshRenderer.material.shader = initialShader;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
