using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _die;
        [SerializeField] private AudioSource _start;

        private void Awake()
        {
            _die.playOnAwake = false;
            _start.playOnAwake = false;
        }

        public void PlayDie() => _die.Play();

        public void PlayStart() => _start.Play();
    }
}
