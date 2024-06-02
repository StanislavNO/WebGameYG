namespace Assets.Source.Code_base
{
    public class RunningState : MovementState
    {
        public RunningState(IStateSwitcher stateSwitcher, Character character, CharacterData data) : base(stateSwitcher, character, data)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = 5;
        }

        public override void Update()
        {
            base.Update();

            if (IsInputZero())
                StateSwitcher.SwitchState<IdleState>();
        }
    }
}