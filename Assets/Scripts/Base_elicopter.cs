using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Base_elicopter : MonoBehaviour
{

    private void Start()
    {

    }

    public void Move()
    {
        transform.DOMove(new Vector3(0f, 0f, 0f), 5f);
    }




}
