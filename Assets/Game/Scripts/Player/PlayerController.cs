using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;

namespace com.Daniela.Player
{

    public class PlayerController : MonoBehaviour
    {


        UnityEngine.Vector3 direction;


        [Header("Player Life Script: ")]
        [Space]
        [SerializeField] private Status _status;
        private PlayerMovement _pM;

        public LayerMask GroundMask;



        void Start()
        {
            _pM = GetComponent<PlayerMovement>();




            _status = GetComponent<Status>();


        }


        void Update()
        {
            float x_axis = Input.GetAxis("Horizontal");
            float z_axis = Input.GetAxis("Vertical");
            Move(x_axis, z_axis);


        }
        void FixedUpdate()
        {


            _pM.MoveCharacter(direction, _status.Speed);
            _pM.RotatePlayer(GroundMask);

        }

        void Move(float x, float z)
        {
            direction = new UnityEngine.Vector3(x, 0, z);
            GetComponent<PlayerAnimations>().SetRun(direction.magnitude);


        }




    }



}