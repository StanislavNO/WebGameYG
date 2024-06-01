using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        private CharacterStateMachine _stateMachine;

        public void Initialize(PlayerInput input)
        {
            Input = input;
            _stateMachine = new();
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