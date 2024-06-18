using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyStateMachine : IStateSwitcher
    {
        private readonly List<IState> _states;

        private IState _currentState;

        public EnemyStateMachine(EnemyData data, Transform enemyTransform, EnemyView enemyView, EnemyConfig config, ICoroutineRunner coroutineRunner, IDisable enemy)
        {
            _states = new List<IState>()
            {
                new StartState(this, data, enemyTransform, enemyView),
                new MoveState(this,enemyView,data,enemyTransform,config),
                new WorkState(this, enemyView, data, coroutineRunner,config),
                new DieState(this, enemyView),
                new DisableState(enemy)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();

        public void Reset() => SwitchState<StartState>();

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}