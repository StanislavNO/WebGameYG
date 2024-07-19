using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Animator))]
    public class CharacterView : MonoBehaviour
    {
        private const string IsIdling = "IsIdling";
        private const string IsRunning = "IsRunning";
        private const string IsAttacking = "IsAttacking";

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterAudioController _audioController;

        public event Action Attacking;
        public event Action EndAttacking;

        public void StartIdling() => _animator.SetBool(IsIdling, true);
        public void StopIdling() => _animator.SetBool(IsIdling, false);

        public void StartRunning() => _animator.SetBool(IsRunning, true);
        public void StopRunning() => _animator.SetBool(IsRunning, false);

        public void StartAttacking()
        {
            _animator.SetBool(IsAttacking, true);
            _audioController.PlayToAttack();
        }

        public void StopAttacking()
        {
            EndAttacking?.Invoke();
            _animator.SetBool(IsAttacking, false);
        }

        public void OnAttackEventInvoke() => Attacking?.Invoke();
    }
}