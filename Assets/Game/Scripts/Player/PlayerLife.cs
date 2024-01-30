using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using com.Daniela.Management;
namespace com.Daniela.Player
{

    public class PlayerLife : MonoBehaviour, IDead
    {


        [Header("Player Controller Script: ")]
        [Space]
        [SerializeField] private PlayerController _pc;

        [Header("Interface Control Script")]
        [Space]

        public Slider SliderLifeBar;

        [Header("Player FX")]
        [Space]
        public AudioClip DamageFx;
        private Status _status;
        [Header("Game Over Script")]
        [Space]
        public GameOver _GameOver;

        void Start()
        {
            Time.timeScale = 1;

            _pc = GetComponent<PlayerController>();
            _status = GetComponent<Status>();
            _status.Life = 100;
            SliderLifeBar.maxValue = _status.Life;
            UpdateSliderLifeBar(_status.Life);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void TakeLife(int damage)
        {

            _status.Life = _status.Life - damage;
            AudioManager.instance.PlayOneShot(DamageFx);
            UpdateSliderLifeBar(_status.Life);
            if (_status.Life <= 0)
            {
                Dead();

            }
        }
        public void UpdateSliderLifeBar(int lifebar)
        {
            SliderLifeBar.value = lifebar;
        }



        public void Dead()
        {

            _GameOver.StartGameOver();
            Time.timeScale = 0;
        }
    }

}