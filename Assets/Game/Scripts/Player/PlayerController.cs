using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace Scripts.Player
{

    public class PlayerController : MonoBehaviour
    {
        public float speed;
        private Rigidbody rb;
        UnityEngine.Vector3 direction;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

      
        void Update()
        {
            float x_axis = Input.GetAxis("Horizontal");
            float z_axis = Input.GetAxis("Vertical");
            Move(x_axis, z_axis);
        }
        void Move(float x, float z)
        {
             direction = new UnityEngine.Vector3(x, 0, z);
          
           
            if(direction != UnityEngine.Vector3.zero)
            {
                GetComponent<PlayerAnimations>().SetRun(true);
            }
            else
            {
                GetComponent<PlayerAnimations>().SetRun(false);
            }
        }
        void FixedUpdate()
        {
          //  rb.MovePosition(rb.position + (direction * speed * Time.deltaTime));
            rb.velocity = direction * speed;
        }
    }

  

}