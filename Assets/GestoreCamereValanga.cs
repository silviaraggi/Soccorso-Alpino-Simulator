using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamereValanga : MonoBehaviour
{
    public void SetFineIntro()
    {
        GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro = false;

    }
    public void TremaCam1()
    {
        GameObject.Find("cam1").GetComponent<Animator>().SetBool("trema", true);
    }
    public void TremaCam2()
    {
        GameObject.Find("cam2_valanga_dettaglio").GetComponent<Animator>().SetBool("trema", true);
    }

}
