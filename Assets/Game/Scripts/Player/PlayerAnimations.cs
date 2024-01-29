using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Daniela.Player

{
    public class PlayerAnimations : MonoBehaviour
    {


        void Start()
        {

        }

        void Update()
        {

        }
        public void SetRun(float run)
        {
            GetComponent<Animator>().SetFloat("Moving",run);
        }
    }

}