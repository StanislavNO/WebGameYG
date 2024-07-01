using UnityEngine;

namespace Assets.Source.Code_base
{
    public class StartState : EnemyState
    {
        private readonly EnemyData _enemyData;

        public StartState(IStateSwitcher switcher, EnemyData enemyData, EnemyView enemyView) : base(switcher, enemyView)
        {
            _enemyData = enemyData;
        }

        public override void Enter()
        {
            base.Enter();

            _enemyData.IsMovingToWork = true;

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