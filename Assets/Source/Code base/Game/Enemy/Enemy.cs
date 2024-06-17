using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(EnemyDeathHandler))]
    public class Enemy : MonoBehaviour, IEnemy, ICoroutineRunner, IDisable
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private EnemyDeathHandler _deathHandler;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;
        private EnemyDeactivator _deactivator;

        public void Initialize(Vector3 target, EnemyDeactivator deactivator)
        {
            _deactivator = deactivator;
            _data = new(target);
            _stateMachine = new(_data, transform, _view, _config, this, this);
        }

        private void OnEnable()
        {
            if (_stateMachine != null)
                _stateMachine.Reset();

            _deathHandler.DamageDetected += OnDie;
        }

        private void OnDisable() =>
            _deathHandler.DamageDetected -= OnDie;

        private void Update() =>
            _stateMachine.Update();

        public void Disable()
        {
            _deactivator.Deactivate(this);
            Debug.Log("Disable");
        }

        public void SetPosition(Vector3 position) =>
            transform.position = position;

        private void OnDie()
        {
            _stateMachine.SwitchState<DieState>();
            _deactivator.Deactivate(this);
            Debug.Log("Die");
        }
    }
}