using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base.UI
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _time;

        private IReadOnlyTimer _timer;

        [Inject]
        private void Construct(IReadOnlyTimer timer)
        {
            _timer = timer;
        }

        private void OnEnable() => _timer.Tick += OnTick;

        private void OnDisable() => _timer.Tick -= OnTick;

        private void OnTick(float second)
        {
            FormatTime(second, out int minute, out int seconds);
            {
                ShowTime(minute, seconds);
            }
        }

        private void ShowTime(int minute, float second)
        {
            string minutes = minute + "m";
            string seconds = second + "s";
            _time.text = minutes + " " + seconds;
        }

        private void FormatTime(float value, out int minute, out int seconds)
        {
            int secondPerMinutes = 60;
            minute = (int)value / secondPerMinutes;
            seconds = (int)value % secondPerMinutes;
        }
    }
}