namespace Assets.Source.Code_base
{
    public class DisableState : IState
    {
        private readonly IEnemyDisable _enemy;

        public DisableState(IEnemyDisable enemy)
        {
            _enemy = enemy;
        }

        public void Enter() => _enemy.Disable(false);

        public void Exit() { }

        public void Update() { }
    }
}