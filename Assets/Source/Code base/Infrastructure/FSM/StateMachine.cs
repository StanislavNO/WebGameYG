using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Code_base.Infrastructure.FSM
{
    public abstract class StateMachine : IStateSwitcher
    {
        public void SwitchState<T>() where T : IState
        {
            throw new System.NotImplementedException();
        }
    }
}