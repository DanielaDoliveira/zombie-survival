using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Daniela.Enemy
{
    public class EnemyAnimations : MonoBehaviour
    {
      
        public void EnemyAttack(bool isAttacking)
        {
            GetComponent<Animator>().SetBool("Atacando", isAttacking);
        }
        public void EnemyMove(float move)
        {
          
            GetComponent<Animator>().SetFloat("Movendo", move);
        }
    }

}