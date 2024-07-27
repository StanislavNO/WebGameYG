using UnityEngine;
namespace Assets.Source.Code_base
{
    public class AttackState : ICharacterState
    {
        private readonly CharacterView _view;
        private readonly AttackPoint _attackPoint;
        private readonly IStateSwitcher _stateSwitcher;

        private bool _isAttacking;

        public AttackState(IStateSwitcher stateSwitcher, Character character)
        {
            _view = character.View;
            _attackPoint = character.AttackPoint;
            _stateSwitcher = stateSwitcher;

            _isAttacking = false;
        }

        public void Enter()
        {
            Debug.Log("Enter" + _isAttacking);
            if (_isAttacking == false)
            {
                _isAttacking = true;

                _view.StartAttacking();
                _view.EndAttacking += OnStopAttacking;
                _view.Attacking += OnAttack;
            }
        }

        public void Exit()
        {
            Debug.Log("Exit" + _isAttacking);

            if (_isAttacking)
            {
                _isAttacking = false;

                _view.EndAttacking -= OnStopAttacking;
                _view.Attacking -= OnAttack;
            }
        }

        public void HandleInput() { }

        public void Update() { }

        private void OnAttack() =>
            _attackPoint.gameObject.SetActive(true);

        private void OnStopAttacking()
        {
            Debug.Log("OnStopAttacking");
            _attackPoint.gameObject.SetActive(false);
            _stateSwitcher.SwitchState<IdleState>();
        }
    }
}