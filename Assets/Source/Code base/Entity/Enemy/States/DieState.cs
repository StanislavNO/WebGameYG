namespace Assets.Source.Code_base
{
    public class DieState : EnemyState
    {
        private readonly EnemyView _view;
        private readonly IEnemyDisable _enemy;

        public DieState(IStateSwitcher switcher,IEnemyDisable enemy, EnemyView view) : base(switcher, view)
        {
            _view = view;
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            _view.StartDie();

            _enemy.Disable(true);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}