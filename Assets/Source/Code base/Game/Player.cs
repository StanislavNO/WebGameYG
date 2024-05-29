using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

namespace Assets.Source.Code_base
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;

        private PlayerInput _input;

        public void Initialize(PlayerInput input)
        {
            _input = input;
        }

        void Update()
        {
            Debug.Log(_input.Player.Move.ReadValue<Vector2>());
            Vector2 input = _input.Player.Move.ReadValue<Vector2>();
            Vector3 direction = new(input.x, 0, input.y);
            _controller.Move(direction * _speed * Time.deltaTime);
        }
    }
}