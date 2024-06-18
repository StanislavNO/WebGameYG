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

        private void Update() => _stateMachine.Update();

        public void Disable() => _deactivator.Deactivate(this);

        public void SetPosition(Vector3 position) =>
            _transform.position = position;

        private void OnDie() =>
            _stateMachine.SwitchState<DieState>();
    }
}