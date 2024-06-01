using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class MovementState : ICharacterState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly CharacterData Data;

        private readonly Character _character;

        public MovementState(IStateSwitcher stateSwitcher, Character character, CharacterData data)
        {
            StateSwitcher = stateSwitcher;
            _character = character;
            Data = data;
        }

        public void Enter()
        {
            Debug.Log(GetType());
        }

        public void Exit(){}
        
        public void HandleInput()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}