using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Enemy : MonoBehaviour, IEnemy, IEnemyDisable, IPause
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private DamageHandler _deathHandler;
        [SerializeField] private Transform _transform;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;
        private EnemyDeactivator _deactivator;

        private bool _isPaused = false;

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

            _deathHandler.IsWork = true;
            _deathHandler.DamageDetected += OnDie;
        }

        private void OnDisable() =>
            _deathHandler.DamageDetected -= OnDie;

        private void FixedUpdate()
        {
            if (_isPaused == false)
                _stateMachine.Update();
        }

        public void Disable(bool isDie) => _deactivator.Deactivate(this, isDie);

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
            _data.StartPosition = _transform.position;
        }

        public void SetPause(bool isPaused) => _isPaused = isPaused;

        private void OnDie()
        {
            _deathHandler.IsWork = false;
            _stateMachine.SwitchState<DieState>();
        }
    }
}