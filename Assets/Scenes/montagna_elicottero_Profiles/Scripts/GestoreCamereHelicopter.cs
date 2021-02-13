using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreCamereHelicopter : MonoBehaviour
{ 
    Base_elicopter helicopter;
    Camera[] telecamere;
    Camera cameranow = null;
    private Transform _parent;
    Camera main;
    [SerializeField] GameObject _NPC;
   

    // Start is called before the first frame update
    void Start()
    {
        helicopter = GameObject.Find("Helicopter").GetComponent<Base_elicopter>();
        telecamere = GetComponentsInChildren<Camera>();
        main = GameObject.Find("Main Camera").GetComponent<Camera>();
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
                    if (cameranow != null)
                        cameranow.enabled = false;
                    cameranow = telecamere[helicopter.GetCamera()];
                    _NPC.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
                }
            }
            else {
                if (cameranow != main)
                {
                    main.enabled = true;
                    if (cameranow != null)
                        cameranow.enabled = false;
                    cameranow = main;
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
