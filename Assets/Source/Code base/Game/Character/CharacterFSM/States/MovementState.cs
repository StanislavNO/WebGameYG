using System;
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

        protected PlayerInput Input => _character.Input;
        protected CharacterController Controller => _character.Controller;

        public void Enter()
        {
            Debug.Log(GetType());
        }

        public void Exit() { }

        public void HandleInput()
        {
            Data.DeltaInput = ReadInput();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        private Vector3 ReadInput()
        {
            Vector2 delta = Input.Player.Move.ReadValue<Vector2>();
            Vector3 worldPosition = new(delta.x, 0, delta.y);

            return worldPosition;
        }
    }
}