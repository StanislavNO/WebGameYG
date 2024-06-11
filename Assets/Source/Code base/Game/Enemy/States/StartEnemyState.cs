using UnityEngine;

namespace Assets.Source.Code_base
{
    public class StartEnemyState : EnemyState
    {
        private readonly EnemyData _enemyData;
        private readonly Transform _enemy;

        public StartEnemyState(IStateSwitcher switcher, EnemyData enemyData, Transform enemy, EnemyView enemyView) : base(switcher, enemyView)
        {
            _enemyData = enemyData;
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            _enemyData.StartPosition = _enemy.position;
            View.Starting();
        }

        public override void Exit()
        {
            base.Exit();

            View.Stopping();
        }

        public override void Update()
        {
            base.Update();

            Switcher.SwitchState<MoveState>();
        }
    }
}