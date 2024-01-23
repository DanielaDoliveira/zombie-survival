using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player

{
    public class PlayerAnimations : MonoBehaviour
    {


        void Start()
        {

        }

        void Update()
        {

        }
        public void SetRun(bool isMoving)
        {
            GetComponent<Animator>().SetBool("Moving", isMoving);
        }
    }

}