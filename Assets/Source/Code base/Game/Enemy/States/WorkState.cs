using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class WorkState : EnemyState
    {
        private readonly EnemyData _enemyData;
        private readonly EnemyView _view;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly WaitForSeconds _delay;

        public WorkState(IStateSwitcher switcher, EnemyView view, EnemyData enemyData, ICoroutineRunner coroutineRunner, EnemyConfig config) : base(switcher, view)
        {
            _enemyData = enemyData;
            _view = view;
            _coroutineRunner = coroutineRunner;
            _delay = new(config.WorkCoolDown);
        }

        public override void Enter()
        {
            base.Enter();

            _view.StartWork();
            _coroutineRunner.StartCoroutine(DelayAndSwitch());
        }

        public override void Exit()
        {
            base.Exit();

            _enemyData.IsMovingToWork = false;
        }

        private IEnumerator DelayAndSwitch()
        {
            yield return _delay;

            Switcher.SwitchState<MoveState>();
        }
    }
}