using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class GameLooper : MonoBehaviour, ICoroutineRunner, IPause
    {
        [SerializeField] private float _secondToGame = 0f;

        private PlayerInput _input;
        private WaitForSeconds _delay;

        private PauseHandler _pauseHandler;
        private Timer _timer;

        [Inject]
        private void Construct(PlayerInput input, PauseHandler pauseHandler, Timer timer)
        {
            _input = input;
            _delay = new(_secondToGame);

            _timer = timer;
            _pauseHandler = pauseHandler;
            _pauseHandler.Add(this);
        }

        private void OnEnable()
        {
            _timer.TimeCanceled += OnGameOver;
            StartCoroutine(EnableInput());
        }

        private void OnDisable()
        {
            _timer.TimeCanceled -= OnGameOver;
            _input.Disable();
        }

        private void OnDestroy() => _pauseHandler.Clear();

        private void Start() => _timer.Start();

        private void Update()
        {
            if (_timer.IsWork)
                _timer.Update(Time.deltaTime);
        }

        private void OnGameOver() => _pauseHandler.SetPause(true);
            
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