using System.Collections;
using System.Collections.Generic;
using com.Daniela.Player;
using com.Daniela.Management;
using UnityEngine;


namespace com.Daniela.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour, IDead
    {

        private CharacterMovement _cM;
        private int _min_damage, _max_damage;
        public Transform Target;
        public Status _status;
        public AudioClip DeathSoundFx;
        private float wander_counter;
        private float time_between_random_pos;
        private int _random_distance;
        private Vector3 random_pos;
        private Vector3 direction;
        private float percent_medicine_kit = 0.1f;
        public GameObject MedicineKitPrefab;
        private InterfaceControl _interfaceControl;
        [HideInInspector] public ZombieGenerator MyGenerator;
        void Start()
        {
            time_between_random_pos = 4;
            _min_damage = 20;
            _max_damage = 30;
            _random_distance = 10;
            _cM = GetComponent<CharacterMovement>();
            _status = GetComponent<Status>();
            Target = GameObject.FindGameObjectWithTag("Jogador").GetComponent<Transform>();
            _interfaceControl = GameObject.FindObjectOfType(typeof(InterfaceControl)) as InterfaceControl;

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
            direction = Target.position - transform.position;
            float v = GetComponent<Rigidbody>().velocity.magnitude;
            GetComponent<EnemyAnimations>().EnemyMove(v);
            if (distance > 15f)
            {
                Wander();
            }
            else if (distance > 2.5f)
            {
                Chase();

            }
            else
            {
                GetComponent<EnemyAnimations>().EnemyAttack(true);

            }
        }


        void EnemyAttackPlayer()
        {
            int damage = Random.Range(_min_damage, _max_damage);
            Target.GetComponent<PlayerLife>().TakeLife(damage);

        }

        public void TakeLife(int damage)
        {
            AudioManager.instance.PlayOneShot(DeathSoundFx);

            _status.Life -= damage;
            if (_status.Life <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            Destroy(gameObject);
            MedicineKitVerifier(percent_medicine_kit);
            _interfaceControl.UpdateDeathZombies();
            MyGenerator.RemoveZombieLiveAmount();
        }
        public void Wander()
        {
            wander_counter -= Time.deltaTime;

            if (wander_counter <= 0)
            {
                random_pos = RandomPositions();
                wander_counter += time_between_random_pos;
            }
            bool near = Vector3.Distance(transform.position, random_pos) <= 0.05;
            if (!near)
            {
                direction = random_pos - transform.position;
                _cM.MoveCharacter(direction, _status.Speed);


            }



        }

        public Vector3 RandomPositions()
        {
            Vector3 pos = Random.insideUnitSphere * _random_distance;
            pos += transform.position;
            pos.y = transform.position.y;
            return pos;
        }
        public void Chase()
        {
            GetComponent<EnemyAnimations>().EnemyAttack(false);
            _cM.MoveCharacter(direction, _status.Speed);
            _cM.CalculateRotation(direction);
        }

        public void MedicineKitVerifier(float gen_percent)
        {
            if (Random.value <= gen_percent)
            {
                Instantiate(MedicineKitPrefab, transform.position, Quaternion.identity);
            }
        }
    }

}