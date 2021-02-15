using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Disperso_neve : MonoBehaviour
{
    public bool canUseSonda;
    public bool ArtvaActive;
    public bool isUsingPala;
    // Start is called before the first frame update
    void Start()
    {
        canUseSonda = false;
        ArtvaActive = false;
        isUsingPala = false;
    }

    private void Update()
    {
        GameObject.Find("FrecciaSolida").GetComponent<Renderer>().enabled = ArtvaActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        canUseSonda = true;
    }

    public bool GetCanUseSonda()
    {
        return canUseSonda;
    }
    public bool GetArtvaActive()
    {
        return ArtvaActive;
    }
    public bool GetisUsingPala()
    {
        return isUsingPala;
    }
    public void SetArtvaActive(bool valore)
    {
        ArtvaActive = valore;
    }

    internal void SetIsUsingPala(bool v)
    {
        isUsingPala = v;
    }
}
