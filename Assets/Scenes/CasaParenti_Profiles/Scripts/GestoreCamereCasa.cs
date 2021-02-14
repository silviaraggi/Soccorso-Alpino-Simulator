using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamereCasa : MonoBehaviour
{ 
    JeepCasa jeep;
    Camera[] telecamere;
    Camera cameranow = null;

    // Start is called before the first frame update
    void Start()
    {
        jeep = GameObject.Find("Jeep").GetComponent<JeepCasa>();
        telecamere = GetComponentsInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().exit_transition();
        if (jeep.GetCamera() >= 0)
        {
            
            if (cameranow != telecamere[jeep.GetCamera()])
            {
                telecamere[jeep.GetCamera()].enabled = true;
                if (cameranow != null)
                    cameranow.enabled = false;
                cameranow = telecamere[jeep.GetCamera()];
            }
        }
    }

    public void DisableCamera(int numero)
    {
        telecamere[numero].enabled = false;
    }
}
