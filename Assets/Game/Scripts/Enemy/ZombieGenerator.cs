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
        private int max_zombie_amount = 2;
        private int zombie_amount;
        private float time_to_add_next_difficult = 20;
        private float time_difficult_counter;


        /* jogo por level: level 1- 6 zumbis, level 2 - 12 level 3 - 18 level 4 - 24 assim por diante. O level será 
        contado no meio da tela dinamicamente em sincronia com a quantidade de zumbis mortos  */

        void Start()
        {

            _target = GameObject.FindGameObjectWithTag("Jogador").GetComponent<Transform>();
            _time_counter = 0;
            _random_distance = 3;
            time_difficult_counter = time_to_add_next_difficult;
            for (int i = 0; i < max_zombie_amount; i++)
            {
                StartCoroutine(CreateZombie());
            }

        }


        void Update()
        {
            float _distance = Vector3.Distance(transform.position, _target.position);
            bool can_generate_for_distance = _distance > _player_distance_to_generate;
            bool can_generate_for_max_zombie_amount = zombie_amount < max_zombie_amount;

            if (can_generate_for_distance && can_generate_for_max_zombie_amount)
            {
                _time_counter += Time.deltaTime;

                if (_time_counter >= timeToGenerate)
                {
                    StartCoroutine(CreateZombie());
                    _time_counter = 0;
                }
            }
            AddDifficult();


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

            EnemyController zombie = Instantiate(Zombie_prefab, creatingInitialPosition, transform.rotation).GetComponent<EnemyController>();
            zombie.MyGenerator = this;
            zombie_amount++;
            Debug.Log("Zombie:" + zombie_amount);


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

        public void RemoveZombieLiveAmount()
        {
            zombie_amount--;
        }
        public void AddDifficult()
        {
            if (Time.timeSinceLevelLoad > time_difficult_counter)
            {
                max_zombie_amount++;
                time_difficult_counter = Time.timeSinceLevelLoad + time_to_add_next_difficult;
            }
        }




    }
}
