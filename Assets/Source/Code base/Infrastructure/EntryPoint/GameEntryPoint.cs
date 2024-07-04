using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class GameEntryPoint : MonoBehaviour, ICoroutineRunner, IPause
    {
        [SerializeField] private float _secondToGame = 0f;

        private PlayerInput _input;
        private WaitForSeconds _delay;

        private PauseHandler _pauseHandler;

        [Inject]
        private void Construct(PlayerInput input, PauseHandler pauseHandler)
        {
            _input = input;
            _delay = new(_secondToGame);

            _pauseHandler = pauseHandler;
            _pauseHandler.Add(this);
        }

        private void OnEnable() => StartCoroutine(EnableInput());

        private void OnDisable() => _input.Disable();

        private void OnDestroy() => _pauseHandler.Clear();

        public void SetPause(bool isPaused)
        {
            if (isPaused)
                _input.Player.Disable();
            else
                _input.Player.Enable();
        }

        private IEnumerator EnableInput()
        {
            yield return _delay;
            _input.Enable();
        }
    }
}