using System.Collections;
using System.Collections.Generic;
using com.Daniela.Enemy;
using com.Daniela.System;
using UnityEngine;

namespace  com.Daniela.Player.Weapon
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody _rb;
       private float _speed;
        
        private int shoot_damage;
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _speed = 30;
            shoot_damage = 1;
        }

        // Update is called once per frame
        void Update()
        {
            MoveBullet();
        }

        void MoveBullet()
        {
            _rb.MovePosition(_rb.position + transform.forward * _speed * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Inimigo"))
            {
              
                other.GetComponent<EnemyController>().TakeLife(shoot_damage);
               
            }
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }

}
