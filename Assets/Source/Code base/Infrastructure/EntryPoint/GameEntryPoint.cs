using Assets.Source.Code_base.UI;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class GameEntryPoint : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private float _secondToGame = 0f;

        private PlayerInput _input;
        private WaitForSeconds _delay;

        [Inject]
        private void Construct(PlayerInput input)
        {
            _input = input;
            _delay = new(_secondToGame);
        }

        private void OnEnable() => StartCoroutine(EnableInput());

        private void OnDisable() => _input.Disable();

        private IEnumerator EnableInput()
        {
            yield return _delay;
            _input.Enable();
        }
    }
}