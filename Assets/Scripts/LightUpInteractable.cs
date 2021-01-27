using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpInteractable : Interactable
{

    Material mat;
    // Start is called before the first frame update
    protected override void Start()
    {
        mat = this.GetComponent<Renderer>().material;
    }

    protected void Update()
    {
        TurnOff();
    }
    public override void GlowUp(GameObject interacter)
    {
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", new Vector4(0.15f, 0.15f, 0.15f, 0));
    }

    public override void TurnOff()
    {
        mat.DisableKeyword("_EMISSION");
    }

    public override void Interact(GameObject interacter)
    {
        throw new System.NotImplementedException();
    }

}
