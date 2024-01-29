using System.Collections;
using System.Collections.Generic;
using com.Daniela.Player;
using com.Daniela.System;
using UnityEngine;


namespace com.Daniela.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour,IDead
    {
       
        private CharacterMovement _cM;
        public Transform Target;
        public Status _status;
        public AudioClip DeathSoundFx;
      
      //  [SerializeField] private float _speed = 5f;
      
        void Start()
        {
            _cM = GetComponent<CharacterMovement>();
            _status = GetComponent<Status>();
            Target = GameObject.FindGameObjectWithTag("Jogador").GetComponent<Transform>();
            

        }

      
        void FixedUpdate()
        {   

            CalculateDistance();

        }

        void CalculateDistance()
        {
            float distance = Vector3.Distance(transform.position, Target.position);
            EnemyActions(distance);
        }

        void EnemyActions(float distance)
        {
            Vector3 direction = Target.position - transform.position;

            if (distance > 2.5f)
            {
                GetComponent<EnemyAnimations>().EnemyAttack(false);
                _cM.MoveCharacter(direction, _status.Speed);
                _cM.CalculateRotation(direction);

            }
            else
            {
                GetComponent<EnemyAnimations>().EnemyAttack(true);
       
            }
        }


        void EnemyAttackPlayer()
        {
            int damage = Random.Range(20, 30);
            Target.GetComponent<PlayerLife>().TakeLife(damage);
          
        }

        public void TakeLife(int damage)
        {
                AudioManager.instance.PlayOneShot(DeathSoundFx);
            
            _status.Life -= damage;
            if(_status.Life<= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            Destroy(gameObject);
        }
    }

}