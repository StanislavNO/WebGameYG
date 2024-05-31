using System;
using UnityEngine;
using UnityEngine.InputSystem;

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

            _input.Player.Move.started += context => Started(context);
            _input.Player.Move.performed += context => Performed(context);
            _input.Player.Move.canceled += context => Canceled(context);

        }

        private void Canceled(InputAction.CallbackContext context)
        {
            Debug.Log("Canceled" + context.duration);
        }

        private void Started(InputAction.CallbackContext context)
        {
            

            Debug.Log("started" + context.duration);
        }

        void Update()
        {
            //if(_input.Player.Move.phase == InputActionPhase.Performed)
            //{
            //    Debug.Log("Performed");
            //}

            //if(_input.Player.Move.phase == InputActionPhase.Started)
            //{
            //    Debug.Log("Started");
            //}
            
            //if(_input.Player.Move.phase == InputActionPhase.Canceled)
            //{
            //    Debug.Log("Canceled");
            //}
            
            //if(_input.Player.Move.phase == InputActionPhase.Waiting)
            //{
            //    Debug.Log("Waiting");
            //}

            //Debug.Log(_input.Player.Move.ReadValue<Vector2>());
            //Vector2 input = _input.Player.Move.ReadValue<Vector2>();
            //Vector3 direction = new(input.x, 0, input.y);
            //_controller.Move(direction * _speed * Time.deltaTime);
        }

        private void Performed(InputAction.CallbackContext context)
        {
            Debug.Log("performed" + context.duration);
        }
    }
}