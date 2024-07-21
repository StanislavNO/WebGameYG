namespace Assets.Source.Code_base
{
    public class DieState : EnemyState
    {
        private readonly IEnemyDisable _enemy;

        public DieState(IStateSwitcher switcher,IEnemyDisable enemy, EnemyView view) : base(switcher, view)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            View.DieAnimationCanceled += OnDieCanceled;
            View.StartDie();
        }

        public override void Exit()
        {
            base.Exit();

            View.DieAnimationCanceled -= OnDieCanceled;
            View.StopDie();
        }

        private void OnDieCanceled()
        {
            _enemy.Disable(true);
            Switcher.SwitchState<NullState>();
        }
    }
}