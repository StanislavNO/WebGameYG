using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class CharacterAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _playerAttack;
        [SerializeField] private AudioSource _weaponAttack;

        private void Awake()
        {
            _playerAttack.playOnAwake = false;
            _weaponAttack.playOnAwake = false;
        }

        public void PlayToAttack()
        {
            _playerAttack.Play();
            _weaponAttack.Play();
        }
    }
}