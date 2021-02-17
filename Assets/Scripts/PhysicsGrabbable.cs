using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Material mat;
    protected override void Start ()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        mat = GetComponent<Renderer>().material;
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = true;
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public override void LightUp(GameObject interacter)
    {
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", new Vector4(0.4f, 0.4f, 0.4f, 0));

    }

    public override void TurnOff()
    {
        mat.DisableKeyword("_EMISSION");
    }
}
