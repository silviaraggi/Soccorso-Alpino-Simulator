using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsGrabbableStretcher : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Material mat;
    private Base_elicopter _parent;
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        mat = GetComponent<Renderer>().material;
        grab = false;
        _parent = transform.parent.GetComponentInParent<Base_elicopter>();
    }

    public override void Grab(GameObject grabber)
    {
        if (grab == false)
            return;
        _collider.enabled = true;
        _rigidbody.isKinematic = true;
        
    }

    public override void Drop()
    {
        if (grab == false)
            return;
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public override void LightUp(GameObject interacter)
    {
        if (grab == false)
            return;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", new Vector4(0.1f, 0.2f, 0, 0));

    }

    public override void TurnOff()
    {
        if (grab == false)
            return;
        mat.DisableKeyword("_EMISSION");
    }
}
