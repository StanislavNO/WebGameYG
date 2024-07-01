using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(DamageHandler))]
    public class Enemy : MonoBehaviour, IEnemy, IDisable
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private DamageHandler _deathHandler;
        [SerializeField] private Transform _transform;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;
        private EnemyDeactivator _deactivator;

        [Inject]
        private void Construct(EnemyTarget target, EnemyDeactivator deactivator, ICoroutineRunner coroutineRunner)
        {
            _deactivator = deactivator;
            _data = new(target.transform.position);
            _stateMachine = new(_data, _transform, _view, _config, coroutineRunner, this);
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

        public void Disable() => _deactivator.Deactivate(this);

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
            _data.StartPosition = _transform.position;
        }

        private void OnDie() =>
            _stateMachine.SwitchState<DieState>();
    }
}