using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;

        public EnemyStateMachine(EnemyData data, Transform enemy, EnemyView enemyView, EnemyConfig config, ICoroutineRunner coroutineRunner)
        {
            _states = new List<IState>()
            {
                new StartEnemyState(this, data, enemy, enemyView),
                new MoveState(this,enemyView,data,enemy,config),
                new WorkState(this, enemyView, data, coroutineRunner,config),
                new DieState(this, enemyView),
                new DisableState()
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState.Update();
        }

        public void Reset()
        {
            SwitchState<StartEnemyState>();
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}