using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(EnemyDeathHandler))]
    public class Enemy : MonoBehaviour, ICoroutineRunner, IDisable
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private EnemyDeathHandler _deathHandler;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Vector3 target)
        {
            _data = new(target);
            _stateMachine = new(_data, transform, _view, _config, this, this);
        }

        public UnityEvent<Enemy> Deactivated;

        private void OnEnable()
        {
            if (_stateMachine != null)
                _stateMachine.Reset();

            _deathHandler.DamageDetected += OnDie;
        }

        private void OnDisable()
        {
            _deathHandler.DamageDetected -= OnDie;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        public void Disable()
        {
            Deactivated?.Invoke(this);
            Debug.Log("Disable");
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void OnDie()
        {
            _stateMachine.SwitchState<DieState>();
            Deactivated?.Invoke(this);
            Debug.Log("Die");
        }
    }
}