using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Grabbable : MonoBehaviour
{
    protected Transform _originalParent;
    public bool grab = true;

    public Transform OriginalParent
    {
        get => _originalParent;
        protected set => _originalParent = value;
    }

    protected virtual void Start()
    {
        _originalParent = transform.parent;
    }

    public abstract void Grab(GameObject grabber);
    public abstract void Drop();
    public abstract void LightUp(GameObject interacter);
    public abstract void TurnOff();

}
