using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class DieState : EnemyState
    {
        private readonly EnemyView _view;

        public DieState(IStateSwitcher switcher, EnemyView view) : base(switcher, view)
        {
            _view = view;
        }

        public override void Enter()
        {
            base.Enter();

            _view.StartDie();

            Switcher.SwitchState<DisableState>();
        }
    }
}