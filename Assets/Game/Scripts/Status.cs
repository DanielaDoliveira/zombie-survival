using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int StartLife = 100;
    [HideInInspector]
    public int Life;
    public float Speed;

    void Start()
    {
       
        Life = StartLife;
    }
}

