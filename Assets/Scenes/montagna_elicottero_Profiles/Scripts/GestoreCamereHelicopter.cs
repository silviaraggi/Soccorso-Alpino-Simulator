using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamereHelicopter : MonoBehaviour
{ 
    Base_elicopter helicopter;
    Camera[] telecamere;
    AudioListener[] audio;
    Camera cameranow = null;
    AudioListener audionow =null;
    private Transform _parent;
    Camera mainCamera;
    AudioListener mainAudio;
    [SerializeField] GameObject _NPC;
   

    // Start is called before the first frame update
    void Start()
    {
        helicopter = GameObject.Find("Helicopter").GetComponent<Base_elicopter>();
        telecamere = GetComponentsInChildren<Camera>();
        audio = GetComponentsInChildren<AudioListener>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainAudio = GameObject.Find("Main Camera").GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (helicopter.GetCamera() >= 0)
        {
            if (helicopter.GetCamera() != 3)
            {
                if (cameranow != telecamere[helicopter.GetCamera()])
                {
                    if (helicopter.GetCamera() == 4)
                        transform.GetChild(4).GetComponent<Animator>().SetBool("fine", true);
                    telecamere[helicopter.GetCamera()].enabled = true;
                    audio[helicopter.GetCamera()].enabled = true;
                    if (cameranow != null)
                    {
                        cameranow.enabled = false;
                        audionow.enabled = false;
                    }
                    cameranow = telecamere[helicopter.GetCamera()];
                    audionow = audio[helicopter.GetCamera()];

                    _NPC.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
                }
            }
            else {
                if (cameranow != mainCamera)
                {
                    mainCamera.enabled = true;
                    mainAudio.enabled = true;
                    if (cameranow != null) { 
                        cameranow.enabled = false;
                        audionow.enabled = false;
                    }
                    cameranow = mainCamera;
                    audionow = mainAudio;
                    _NPC.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
                }
            }
        }
    }

    public void DisableCamera(int numero)
    {
        telecamere[numero].enabled = false;
    }
}
