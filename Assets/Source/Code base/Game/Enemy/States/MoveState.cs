using UnityEngine;

namespace Assets.Source.Code_base
{
    public class MoveState : EnemyState
    {
        private readonly EnemyData _enemyData;
        private readonly float _step;
        private readonly float _offsetToTarget;

        private Transform _transform;
        private Vector3 _currentTarget;

        public MoveState(IStateSwitcher switcher, EnemyView view, EnemyData enemyData, Transform enemyTransform, EnemyConfig config) : base(switcher, view)
        {
            _enemyData = enemyData;
            _transform = enemyTransform;
            _step = config.MoveStateConfig.Speed;
            _offsetToTarget = config.OffsetToTarget;
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

            if (TryTouchToTarget())
            {
                if (_enemyData.IsMovingToWork)
                    Switcher.SwitchState<WorkState>();

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
                _step * Time.deltaTime);

            _transform.position = position;
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