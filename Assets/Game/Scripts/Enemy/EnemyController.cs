using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour
    {
        Rigidbody _rb;
        public Transform target;
        [SerializeField] private float _speed = 5f;
      
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            Vector3 direction = target.position - transform.position;
            Move(direction);

        }
        void Move(Vector3 direction)
        {
           
           _rb.MovePosition(_rb.position + direction * _speed * Time.deltaTime);
        }
    }

}