using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] EnemyConfig _config;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Vector3 target)
        {
            _data = new(target);
            _stateMachine = new(_data, transform, _view, _config, this);
        }

        private void OnEnable()
        {
            if (_stateMachine != null)
                _stateMachine.Reset();
        }

        private void Update() => _stateMachine.Update();

        private void OnTriggerEnter(Collider other)
        {
            if (TryGetComponent<AttackPoint>(out _))
                _stateMachine.SwitchState<DieState>();
        }
    }
}