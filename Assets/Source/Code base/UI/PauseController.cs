using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Source.Code_base.UI
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _playButton;

        private PauseHandler _pauseHandler;

        [Inject]
        private void Construct(PauseHandler pauseHandler)
        {
            _pauseHandler = pauseHandler;
            _pauseButton.gameObject.SetActive(true);
            _playButton.gameObject.SetActive(false);
        }

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseClick);
            _playButton.onClick.AddListener(OnPlayClick);
        }

        private void OnDestroy()
        {
            _pauseButton.onClick.RemoveListener(OnPauseClick);
            _playButton.onClick.RemoveListener(OnPlayClick);
        }

        private void OnPlayClick()
        {
            _playButton.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
            _pauseHandler.SetPause(false);
        }

        private void OnPauseClick()
        {
            _pauseButton.gameObject.SetActive(false);
            _playButton.gameObject.SetActive(true);
            _pauseHandler.SetPause(true);
        }
    }
}
