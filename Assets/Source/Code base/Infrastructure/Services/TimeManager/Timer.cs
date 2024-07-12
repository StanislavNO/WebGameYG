using System;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Timer : ITimer, IReadOnlyTimer, IPause
    {
        private const float SecondsPerMinute = 60;
        private readonly float StartMinutes;

        private float _currentValue;

        [Inject]
        public Timer(PauseHandler pauseHandler)
        {
            StartMinutes = 1.2f;
            _currentValue = StartMinutes * SecondsPerMinute;
            IsWork = false;

            pauseHandler.Add(this);
        }

        public event Action<float> Tick;
        public event Action TimeCanceled;

        public bool IsWork { get; private set; }

        public void Start() => IsWork = true;
        public void Stop() => IsWork = false;

        public void Update(float deltaTime)
        {
            if (IsWork == false)
                return;

            HandleTime(deltaTime);
        }

        public void SetPause(bool isPaused) => IsWork = !isPaused;

        private void HandleTime(float deltaTime)
        {
            if (deltaTime < 0)
                throw new ArgumentOutOfRangeException(nameof(deltaTime));

            int second = (int)_currentValue;

            _currentValue -= deltaTime;

            if (second != _currentValue)
                Tick?.Invoke(_currentValue);

            if (_currentValue <= 0)
            {
                IsWork = false;
                TimeCanceled?.Invoke();
            }
        }
    }
}
