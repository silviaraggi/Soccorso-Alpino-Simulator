using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cash : MonoBehaviour
{
    public Text textDisplay;
    public int punteggio;


    // Update is called once per frame
    void Update()
    {
        punteggio = FindObjectOfType<SceneInfo>().GetPunteggio();
        textDisplay.GetComponent<Text>().text = punteggio.ToString();

    }

  
}
