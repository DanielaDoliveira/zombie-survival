using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Daniela.Enemy
{

    public class BossGenerator : MonoBehaviour
    {
        private float time_to_next_gen = 0;
        public float TimeBetweenGens = 60;
        public GameObject BossPrefab;
        private InterfaceControl _interfaceControl;

        public Transform[] GeneratePositions;
        private Transform _target;
        void Start()
        {
            time_to_next_gen = TimeBetweenGens;
            _interfaceControl = GameObject.FindObjectOfType(typeof(InterfaceControl)) as InterfaceControl;
            _target = GameObject.FindWithTag("Jogador").transform;
        }

        // Update is called once per frame
        void Update()
        {
            CreateBoss();
            if (CreateBoss())
            {
                Vector3 _creationDistance = CalculateMostDistance();
                Instantiate(BossPrefab, _creationDistance, Quaternion.identity);
                _interfaceControl.AppearBossWarning();
                time_to_next_gen = Time.timeSinceLevelLoad + TimeBetweenGens;

            }
        }
        bool CreateBoss()
        {
            bool can_create = Time.timeSinceLevelLoad > time_to_next_gen;

            return can_create;
        }

        Vector3 CalculateMostDistance()
        {
            Vector3 _calculateMostDistance = Vector3.zero;
            float _mostDistance = 0;
            foreach (Transform positions in GeneratePositions)
            {
                float _distanceBetweenPlayer = Vector3.Distance(positions.position, _target.position);
                if (_distanceBetweenPlayer > _mostDistance)
                {
                    _mostDistance = _distanceBetweenPlayer;
                    _calculateMostDistance = positions.position;
                }
            }
            return _calculateMostDistance;
        }


    }

}