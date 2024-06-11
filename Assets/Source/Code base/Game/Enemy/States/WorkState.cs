namespace Assets.Source.Code_base
{
    public class WorkState : EnemyState
    {
        private EnemyData _enemyData;

        public WorkState(IStateSwitcher switcher, EnemyView view, EnemyData enemyData) : base(switcher, view)
        {
            _enemyData = enemyData;
        }

        public override void Exit()
        {
            base.Exit();

            _enemyData.IsMovingToWork = false;
        }
    }
}