using System;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class DisableState : IState
    {
        private IDisable _enemy;

        public DisableState(IDisable enemy)
        {
            _enemy = enemy;
        }

        public void Enter() => _enemy.Disable();

        public void Exit() { }

        public void Update() { }
    }
}