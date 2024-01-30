using System.Collections;
using System.Collections.Generic;
using com.Daniela.Management;
using UnityEngine;

namespace com.Daniela.Player.Weapon
{
    public class WeaponController : MonoBehaviour
    {

        public GameObject Bullet_prefab;
        public Transform Bullet_pos;
        public AudioClip shoot_fx;
        void Start()
        {

        }

        void Update()
        {
            PlayerAttack();
        }

        void PlayerAttack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(Bullet_prefab, Bullet_pos.position, Bullet_pos.rotation);
                AudioManager.instance.PlayOneShot(shoot_fx);
;            }
        }
    }

}