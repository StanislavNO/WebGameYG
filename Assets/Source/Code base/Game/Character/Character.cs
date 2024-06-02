﻿using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        private CharacterStateMachine _stateMachine;
        private CharacterData _data;

        public void Initialize(PlayerInput input)
        {
            Input = input;
            _data = new();
            _stateMachine = new(this , _data);
        }

        [field: SerializeField]
        public CharacterController Controller { get; private set; }
        public PlayerInput Input { get; private set; }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }
    }
}