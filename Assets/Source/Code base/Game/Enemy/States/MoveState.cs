using UnityEngine;

namespace Assets.Source.Code_base
{
    public class MoveState : EnemyState
    {
        private readonly EnemyData _enemyData;
        private readonly float _speed;
        private readonly float _offsetToTarget;
        private readonly Transform _transform;

        private Vector3 _currentTarget;

        public MoveState(IStateSwitcher switcher, EnemyView view, EnemyData enemyData, Transform enemyTransform, EnemyConfig config) : base(switcher, view)
        {
            _enemyData = enemyData;
            _speed = config.MoveStateConfig.Speed;
            _offsetToTarget = config.OffsetToTarget;
            _transform = enemyTransform;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartMoving();
            SetCurrentTarget();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopMoving();
        }

        public override void Update()
        {
            base.Update();

            MoveToTarget();
            RotationToTarget();

            if (TryTouchToTarget())
            {
                if (_enemyData.IsMovingToWork)
                    Switcher.SwitchState<WorkState>();
                else
                    Switcher.SwitchState<DisableState>();
            }
        }

        private bool TryTouchToTarget()
        {
            float distance = (_currentTarget - _transform.position).magnitude;

            if (distance < _offsetToTarget)
                return true;

            return false;
        }

        private void MoveToTarget()
        {
            Vector3 position = Vector3.MoveTowards(
                _transform.position,
                _currentTarget,
                _speed * Time.deltaTime);

            position.y = _transform.position.y;
            _transform.position = position;
        }

        private void RotationToTarget()
        {
            Vector3 target = new(_currentTarget.x, _transform.position.y , _currentTarget.z);

            _transform.LookAt(target);
        }

        private void SetCurrentTarget()
        {
            if (_enemyData.IsMovingToWork)
                _currentTarget = _enemyData.TargetPosition;
            else
                _currentTarget = _enemyData.StartPosition;
        }
    }
}