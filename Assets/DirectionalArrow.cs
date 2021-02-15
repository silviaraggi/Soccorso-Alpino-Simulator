using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    float dist;
    Color far;
    Color near;
    float MAX_DISTANCE;
    private void Start()
    {
        far = Color.black;
        near = Color.red;
        MAX_DISTANCE = 2000.02f;
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
        float distanceApart = getSqrDistance(GameObject.Find("Player").transform.position, GameObject.Find("Disperso_gameplay").transform.position);

        //Convert 0 and 200 distance range to 0f and 1f range
        float lerp = mapValue(distanceApart, 0, MAX_DISTANCE, 0f, 1f);

        //Lerp Color between near and far color
        Color lerpColor = Color.Lerp(near, far, lerp);
        this.GetComponentInChildren<Renderer>().material.color = lerpColor;

    }
    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
    public float getSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }
}
