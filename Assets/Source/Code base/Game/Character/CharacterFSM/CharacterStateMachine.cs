using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.Code_base
{
    public class CharacterStateMachine : IStateSwitcher
    {
        private List<ICharacterState> _states;
        private ICharacterState _currentState;

        public CharacterStateMachine()
        {
            _states = new List<ICharacterState>()
            {

            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            ICharacterState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void HandleInput() => _currentState.HandleInput();

        public void Update() => _currentState.Update();
    }
}