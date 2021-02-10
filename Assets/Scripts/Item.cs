using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public abstract class Item : ScriptableObject
{
    new public string name="New Item";
    public RawImage icon = null;
    public bool isDefaultItem = false;
    public int ID;


    //bool mouseOver = false;
    public abstract void Start();

    public abstract void OnMouseEnter();
    public abstract void OnMouseExit();

    public abstract void OnPointerClick(PointerEventData eventData);

    public abstract void Use();
}
