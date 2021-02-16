using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void Start();

    /*protected abstract void Update();*/

    public abstract void Interact(GameObject interacter, Interactable interacted);

    public abstract void GlowUp(GameObject gameObject);

    public abstract void TurnOff();

    public abstract bool GetAnimatable();

    public abstract bool GetCollectable();

    public abstract bool GetInteract();


    public abstract bool GetCollect();

    public abstract void SetAnimatable(bool newvalue);

    public abstract void SetCollectable(bool newvalue);

    public abstract void SetInteract(bool newvalue);

    public abstract void SetCollect(bool newvalue);

}
