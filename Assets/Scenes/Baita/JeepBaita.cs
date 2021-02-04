using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepBaita : MonoBehaviour
{
    int scenario;
    // Start is called before the first frame update
    void Start()
    {
        scenario = GameObject.Find("SceneInfo").GetComponent<SceneInfo>().GetScene();
        if (scenario == 1) //elicottero
        {
            this.GetComponent<LightUpInteractable>().SetAnimatable(false);
            //robaelicottero
        }
        if(scenario == 2)
        {
            this.GetComponent<LightUpInteractable>().SetAnimatable(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
