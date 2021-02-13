using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamereValanga : MonoBehaviour
{
    public void SetFineIntro()
    {
        GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro = false;

    }
}
