using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    Vector3 distance;
    void Start()
    {
        distance = transform.position - target.position;
    }

   
    void Update()
    {
        transform.position = target.position + distance;
    }
}
