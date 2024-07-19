using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Source.Code_base
{
    public abstract class MovementState : ICharacterState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly CharacterData Data;

        private readonly Character _character;
        private readonly Transform _characterTransform;

        private float _currentSpeed = 0;

        public MovementState(IStateSwitcher stateSwitcher, Character character, CharacterData data)
        {
            StateSwitcher = stateSwitcher;
            _character = character;
            Data = data;

            _characterTransform = _character.transform;
        }

        protected PlayerInput Input => _character.Input;
        protected CharacterController Controller => _character.Controller;
        protected CharacterView View => _character.View;

        public virtual void Update()
        {
            MovePlayer();
            RotationPlayer();
        }

        public virtual void Enter() =>
            AddInputActionsCallbacks();

        public virtual void Exit() =>
            RemoveInputActionsCallbacks();

        public void HandleInput() =>
            Data.SetDirection(ReadInput());

        protected bool IsInputZero() =>
            ReadInput() == Vector2.zero;

        protected virtual void AddInputActionsCallbacks() =>
            Input.Player.Attack.started += OnAttackPressed;

        protected virtual void RemoveInputActionsCallbacks() =>
            Input.Player.Attack.started -= OnAttackPressed;

        private void MovePlayer()
        {
            float lerpAmount = 1f;

            _currentSpeed = Mathf.MoveTowards(_currentSpeed, Data.Speed, lerpAmount);
            Controller.Move(_currentSpeed * Time.deltaTime * Data.Direction);
        }

        private void RotationPlayer()
        {
            float lerpAmount = 0.05f;
            Vector3 direction = Data.Direction;
            direction.y = 0;

            _characterTransform.forward =
                Vector3.Slerp(_character.transform.forward, direction, lerpAmount);
        }

        private Vector2 ReadInput() =>
            Input.Player.Move.ReadValue<Vector2>();

        private void OnAttackPressed(InputAction.CallbackContext _)
        {
            StateSwitcher.SwitchState<AttackState>();
        }
    }
}