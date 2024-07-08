using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _system;
        [SerializeField] AudioClip _clip;

        public void ShowSpawn()
        {
            _system.Play();
        }
    }
}