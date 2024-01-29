using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void MoveCharacter(Vector3 direction, float speed)
    {
        _rb.velocity = direction * speed;
       // _rb.MovePosition(_rb.position + (direction * speed * Time.deltaTime));
    }
    public void CalculateRotation(Vector3 direction)
    {
        Quaternion new_rotation = Quaternion.LookRotation(direction);
        _rb.MoveRotation(new_rotation);
    }
}
