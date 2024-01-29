using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Daniela.cameras
{

    public class CameraController : MonoBehaviour
    {

        public Transform Target;
        Vector3 distance;
        void Start()
        {
            Target = GameObject.FindGameObjectWithTag("Jogador").GetComponent<Transform>();
            distance = transform.position - Target.position;

        }


        void Update()
        {

            transform.position = Target.position + distance;
        }
    }

}