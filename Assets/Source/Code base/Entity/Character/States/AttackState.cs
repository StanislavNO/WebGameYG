using UnityEngine;
using Zenject;
namespace Assets.Source.Code_base
{
    public class AttackState : ICharacterState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly AttackPoint _attackPoint;
        private readonly CharacterView _view;

        private readonly WaitForSeconds _delay;
        private ICoroutineRunner _coroutineRunner;

        private Coroutine _attackCoroutine;

        public AttackState(IStateSwitcher stateSwitcher, Character character)
        {
            _stateSwitcher = stateSwitcher;
            _attackPoint = character.AttackPoint;
            _view = character.View;

            _delay = new(character.Config.AttackStateConfig.CoolDown);
            _coroutineRunner = character;
        }

        public void Enter()
        {
            _view.StartAttacking();
            _view.EndAttacking += OnStopAttacking;
            _view.Attacking += OnAttack;
        }

        public void Exit()
        {
            _view.EndAttacking -= OnStopAttacking;
            _view.Attacking -= OnAttack;
        }

        public void HandleInput() { }

        public void Update() { }

        private void OnAttack() =>
            _attackPoint.gameObject.SetActive(true);

        private void OnStopAttacking()
        {
            _attackPoint.gameObject.SetActive(false);
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}