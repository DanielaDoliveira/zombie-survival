using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace com.Daniela.Enemy
{

    public class ChooseZombieType : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ChooseZombie();
        }


        public void ChooseZombie()
        {
            int zombie_type = Random.Range(1, transform.childCount);
            transform.GetChild(zombie_type).gameObject.SetActive(true);

        }
    }

}