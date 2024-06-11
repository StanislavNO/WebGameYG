using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class AttackState : ICharacterState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly AttackPoint _attackPoint;
        private readonly CharacterView _view;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly WaitForSeconds _delay;

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
            _attackCoroutine = _coroutineRunner.StartCoroutine(Attack());
        }

        public void Exit()
        {
            _view.StopAttacking();
            _coroutineRunner.StopCoroutine(_attackCoroutine);
        }

        public void HandleInput(){}

        public void Update(){}

        private IEnumerator Attack()
        {
            _attackPoint.gameObject.SetActive(true);

            yield return _delay;

            _attackPoint.gameObject.SetActive(false);
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}