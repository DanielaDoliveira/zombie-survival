using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Daniela.Management
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        public static AudioSource instance;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            instance = _audioSource;
        }


    }

}