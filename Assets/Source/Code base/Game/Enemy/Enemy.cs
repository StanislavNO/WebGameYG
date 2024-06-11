using UnityEngine;

namespace Assets.Source.Code_base
{
    public class Enemy : MonoBehaviour, IPositionInWorld
    {
        [SerializeField] private EnemyView _view;
        [SerializeField] EnemyConfig _config;

        private EnemyData _data;
        private EnemyStateMachine _stateMachine;

        public void Initialize(Vector3 target)
        {
            _data = new(target);
            _stateMachine = new(_data, transform, _view, _config);
        }

        public Vector3 Position => transform.position;

        private void OnEnable()
        {
            if (_stateMachine != null)
                _stateMachine.Reset();
        }

        private void Update() => _stateMachine.Update();
    }
}