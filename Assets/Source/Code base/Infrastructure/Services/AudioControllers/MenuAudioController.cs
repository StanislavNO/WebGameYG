using UnityEngine;

namespace Assets.Source.Code_base
{
    public class MenuAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _audioSource.Play();
        }
    }
}