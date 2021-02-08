using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonda_selezionabile : MonoBehaviour

{

    public GameObject Sonda_aperta;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            Sonda_aperta = GameObject.Find("Sonda_aperta");


    }
}
