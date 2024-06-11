namespace Assets.Source.Code_base
{
    public class RunningState : MovementState
    {
        private readonly RunningStateConfig _config;

        public RunningState(IStateSwitcher stateSwitcher, Character character, CharacterData data) : base(stateSwitcher, character, data)
        {
            _config = character.Config.RunningStateConfig;
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = _config.Speed;
            View.StartRunning();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopRunning();
        }

        public override void Update()
        {
            base.Update();

            if (IsInputZero())
                StateSwitcher.SwitchState<IdleState>();
        }
    }
}