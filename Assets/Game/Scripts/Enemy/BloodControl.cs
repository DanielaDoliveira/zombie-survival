using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BloodControl : MonoBehaviour
{
    public ParticleSystem Blood;

    public void BloodParticle(Vector3 position, Quaternion rotation)
    {
        Instantiate(Blood, position, rotation);
    }
}

