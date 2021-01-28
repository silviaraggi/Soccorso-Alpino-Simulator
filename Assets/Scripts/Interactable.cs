using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void Start();

    /*protected abstract void Update();*/

    public abstract void Interact(GameObject interacter);

    public abstract void GlowUp(GameObject gameObject);

    public abstract void TurnOff();

}
