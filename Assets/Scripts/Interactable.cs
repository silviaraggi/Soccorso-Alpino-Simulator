using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void Start();

    public abstract void Interact(GameObject interacter);

    public abstract void GlowUp(GameObject interacter);

    public abstract void TurnOff();
}
