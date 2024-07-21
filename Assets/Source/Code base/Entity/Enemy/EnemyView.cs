using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyView : MonoBehaviour
    {
        private const string IsRunning = "IsRunning";
        private const string DieTrigger = "Died";
        private const string IsWork = "IsWork";

        [SerializeField] private Animator _animator;
        [SerializeField] private EnemyAudioController _audioController;

        public event Action DieAnimationCanceled;

        public void Starting() =>
            _audioController.PlayStart();

        public void Stopping() { }

        public void StartMoving() =>
            _animator.SetBool(IsRunning, true);

        public void StopMoving() =>
            _animator.SetBool(IsRunning, false);

        public void StartWork() =>
            _animator.SetBool(IsWork, true);

        public void StopWork() =>
            _animator.SetBool(IsWork, false);

        public void StartDie()
        {
            _animator.SetTrigger(DieTrigger);
            _audioController.PlayDie();
        }

        public void OnDieCanceledEventInvoke() =>
            DieAnimationCanceled?.Invoke();

        public void StopDie() { }
    }
}