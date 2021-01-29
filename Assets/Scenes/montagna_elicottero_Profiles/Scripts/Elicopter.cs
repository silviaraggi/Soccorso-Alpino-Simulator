using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Elicopter : MonoBehaviour
{

    private void Start()
    {
        
    }

    public void Rotate(int flag)
    {
        if (flag == 0)
            transform.DORotate(new Vector3(0f, 360f, 0f), 0.4f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart);
        else if (flag == 1)
            transform.DORotate(new Vector3(0f, 360f, 0f), 1.2f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart);
    }

    public void Move()
    {
        transform.DOMove(new Vector3(0f, -6f, 0f), 5f);
    }




}
