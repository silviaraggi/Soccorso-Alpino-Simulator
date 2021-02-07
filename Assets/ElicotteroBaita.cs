using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElicotteroBaita : MonoBehaviour
{
    public void CaricaScenaElicottero()
    {
        GameObject.Find("GestoreScene").GetComponent<GestoreScene>().LoadSceneByID(2);
    }
}
