using UnityEngine;

namespace Assets.Source.Code_base
{
    public class StartState : EnemyState
    {
        private readonly EnemyData _enemyData;
        private readonly Transform _enemy;

        public StartState(IStateSwitcher switcher, EnemyData enemyData, Transform enemy, EnemyView enemyView) : base(switcher, enemyView)
        {
            _enemyData = enemyData;
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            _enemyData.IsMovingToWork = true;
            _enemyData.StartPosition = _enemy.position;
            View.Starting();
            Switcher.SwitchState<MoveState>();
        }

        public override void Exit()
        {
            base.Exit();

            View.Stopping();
        }
    }
}