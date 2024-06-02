using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class IdleState : MovementState
    {
        public IdleState(IStateSwitcher stateSwitcher, Character character, CharacterData data) : base(stateSwitcher, character, data)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Data.Speed = 0;
        }

        public override void Update()
        {
            base.Update();

            if(IsInputZero())
                return;

            StateSwitcher.SwitchState<RunningState>();
        }
    }
}