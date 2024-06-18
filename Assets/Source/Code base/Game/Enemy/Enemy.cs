using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(DamageHandler))]
    public class Enemy : MonoBehaviour, IEnemy, ICoroutineRunner, IDisable
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private DamageHandler _deathHandler;
        [SerializeField] private Transform _transform;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Vector3 target)
        {
            _data = new(target);
            _stateMachine = new(_data, transform, _view, _config, this, this);
        }

        public event Action<Enemy> Deactivated; 

        private void OnEnable()
        {
            if (_stateMachine != null)
                _stateMachine.Reset();

            _deathHandler.DamageDetected += OnDie;
        }

        private void OnDisable() =>
            _deathHandler.DamageDetected -= OnDie;

        private void Update() => _stateMachine.Update();

        public void Disable()
        {
            Deactivated?.Invoke(this);
            Debug.Log("Enemy Disable");
        }

        public void SetPosition(Vector3 position) =>
            _transform.position = position;

        private void OnDie() =>
            _stateMachine.SwitchState<DieState>();
    }
}