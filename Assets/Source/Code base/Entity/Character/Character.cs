using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, ICoroutineRunner
    {
        private CharacterStateMachine _stateMachine;
        private CharacterData _data;

        [Inject]
        private void Construct(PlayerInput input)
        {
            Input = input;
            _data = new();
            _stateMachine = new(this, _data);
        }

        [field: SerializeField] public CharacterView View { get; private set; }
        [field: SerializeField] public CharacterController Controller { get; private set; }
        [field: SerializeField] public CharacterConfig Config { get; private set; }
        [field: SerializeField] public AttackPoint AttackPoint { get; private set; }

        public PlayerInput Input { get; private set; }

        private void Update()
        {
            _stateMachine.HandleInput();
            _stateMachine.Update();
        }
    }
}