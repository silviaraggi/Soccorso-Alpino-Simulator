using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    public string nome;
    public int ID;

    public Inventory inventory;
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
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            inventory.Add(this);
            print("Aggiunto");
        }
    }
}
