namespace Assets.Source.Code_base
{
    public class DisableState : IState
    {
        private readonly IDisable _enemy;
        private readonly IStateSwitcher _switcher;

        public DisableState(IDisable enemy, IStateSwitcher switcher)
        {
            _enemy = enemy;
            _switcher = switcher;
        }

        public void Enter() => _switcher.SwitchState<InPoolState>();

        public void Exit() => _enemy.Disable();

        public void Update() { }
    }
}