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
        transform.DOMove(new Vector3(2.15f, 0f, -2.09f), 5f);
    }




}
