using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeep : MonoBehaviour
{

    bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LightUpInteractable>().SetAnimatable(false);
    }

    // Update is called once per frame
    void Update()
    {
        canStart = GameObject.Find("magliasolida").GetComponent<LightUpInteractable>().GetCollect();
        if (canStart)
            GetComponent<LightUpInteractable>().SetAnimatable(true);
        if(!canStart)
            GetComponent<LightUpInteractable>().SetAnimatable(false);
        Move();
    }
    public void Move()
    {
        if(GetComponent<LightUpInteractable>().GetInteract())
        transform.DOMove(new Vector3(278f, 5.31f, 245.12f), 5f);
    }
}
