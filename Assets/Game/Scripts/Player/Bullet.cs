using System;
using System.Collections;
using System.Collections.Generic;
using com.Daniela.Enemy;
using com.Daniela.Management;
using UnityEngine;

namespace com.Daniela.Player.Weapon
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
            Quaternion bulletInvertedPosition = Quaternion.LookRotation(-transform.forward);
            switch (other.tag)
            {
                case "Inimigo":
                    other.GetComponent<EnemyController>().TakeLife(shoot_damage);
                    other.GetComponent<BloodControl>().BloodParticle(transform.position, bulletInvertedPosition);
                    break;
                case "Boss":
                    other.GetComponent<BossController>().TakeLife(shoot_damage);
                    other.GetComponent<BloodControl>().BloodParticle(transform.position, bulletInvertedPosition);
                    break;

            }


            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }

}
