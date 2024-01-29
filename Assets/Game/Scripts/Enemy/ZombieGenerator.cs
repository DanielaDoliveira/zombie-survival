using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Daniela.Enemy
{

    public class ZombieGenerator : MonoBehaviour
    {
        [Header("Enemy:")]
        [Space]
        public GameObject Zombie_prefab;
        [Header("Time to Generate:")]
        [Space]
        public float timeToGenerate;

        private float _time_counter;

       
        void Start()
        {
           
           
        _time_counter = 0;
        

    }


    void Update()
        {
            CreateZombie();
        }

        void CreateZombie()
        {
            _time_counter += Time.deltaTime;
          
            if (_time_counter>= timeToGenerate)
            {
                Instantiate(Zombie_prefab, transform.position, transform.rotation);
                _time_counter = 0;
            }
        }

    


    }
}
