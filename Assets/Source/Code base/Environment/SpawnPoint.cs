using UnityEngine;

namespace Assets.Source.Code_base
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _system;
        [SerializeField] private AudioSource _audio;

        public void ShowSpawn()
        {
            _audio.Play();
            _system.Play();
        }
    }
}