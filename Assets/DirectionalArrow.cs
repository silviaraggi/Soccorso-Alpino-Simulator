using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    float dist;
    Color colorStart;
    Color colorAlpha;
    private void Start()
    {
        colorStart = Color.black;
        colorAlpha = Color.red;
    }
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 signPosition = new Vector3(transform.position.x, 0, transform.position.z);
        // set the Y coordinate according to terrain Y at that point:
        signPosition.y = Terrain.activeTerrain.SampleHeight(signPosition) + Terrain.activeTerrain.GetPosition().y;
        // you probably want to create the object a little above the terrain:
        signPosition.y += 0.5f; // move position 0.5 above the terrain
        transform.position = signPosition;
        //targetPosition.y = transform.position.y;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
        dist = Vector3.Distance(targetPosition, this.transform.position);
        GetComponentInChildren<Renderer>().material.color = Color.Lerp(colorStart, colorAlpha, dist);

    }
}
