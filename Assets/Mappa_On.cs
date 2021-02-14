using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mappa_On : MonoBehaviour
{
    public GameObject mappa_on;
    // Update is called once per frame


    public void LightUp()
    {
        mappa_on.SetActive(true);
    }
}
