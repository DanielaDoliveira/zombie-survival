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
        private int _random_distance = 3;
        public LayerMask LayerEnemy;
        private Transform _target;
        private float _player_distance_to_generate = 20;


        void Start()
        {

            _target = GameObject.FindGameObjectWithTag("Jogador").GetComponent<Transform>();
            _time_counter = 0;
            _random_distance = 3;

        }


        void Update()
        {
            float _distance = Vector3.Distance(transform.position, _target.position);
            if (_distance > _player_distance_to_generate)
            {
                _time_counter += Time.deltaTime;

                if (_time_counter >= timeToGenerate)
                {
                    StartCoroutine(CreateZombie());
                    _time_counter = 0;
                }
            }

        }

        IEnumerator CreateZombie()
        {
            Random.InitState((int)System.DateTime.Now.Ticks);

            Vector3 creatingInitialPosition = RandomPositions();

            Collider[] has_enemy = Physics.OverlapSphere(creatingInitialPosition, 1, LayerEnemy);

            while (has_enemy.Length > 0)
            {
                creatingInitialPosition = RandomPositions();
                has_enemy = Physics.OverlapSphere(creatingInitialPosition, 1, LayerEnemy);
                yield return null;


            }

            Instantiate(Zombie_prefab, creatingInitialPosition, transform.rotation);




        }

        public Vector3 RandomPositions()
        {

            Vector3 pos = Random.insideUnitSphere * _random_distance;
            pos += transform.position;
            pos.y = 0;
            return pos;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _random_distance);
        }





    }
}
