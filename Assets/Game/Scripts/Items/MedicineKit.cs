using System.Collections;
using System.Collections.Generic;
using com.Daniela.Player;
using UnityEngine;

public class MedicineKit : MonoBehaviour
{
    private int life_amount = 15;
    private int destroy_time = 5;
    private MeshRenderer _mesh;
    private void Start()
    {
        Destroy(gameObject, destroy_time);
        _mesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            other.gameObject.GetComponent<PlayerLife>().AddLife(life_amount);
            Destroy(gameObject);
        }
    }

}
