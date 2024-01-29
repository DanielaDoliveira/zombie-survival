using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Daniela.Player
{

    public class PlayerController : MonoBehaviour
    {
      
     
        UnityEngine.Vector3 direction;
        public GameObject GameOverPanel;

        [Header("Player Life Script: ")]
        [Space]
       [SerializeField]private Status _status;
        private PlayerMovement _pM;

        public LayerMask GroundMask;

        private int _scene;
        void Start()
        {
            _pM = GetComponent<PlayerMovement>();
            _scene = SceneManager.GetActiveScene().buildIndex;
         
            GameOverPanel.SetActive(false);

            _status = GetComponent<Status>();
            Time.timeScale = 1;
         
        }

      
        void Update()
        {
            float x_axis = Input.GetAxis("Horizontal");
            float z_axis = Input.GetAxis("Vertical");
            Move(x_axis, z_axis);
            CheckLive();

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
       public void CheckLive()
        {
            
            if (_status.Life <=0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                   SceneManager.LoadScene(_scene);
                }
            }
        }

       
        
    }

  

}