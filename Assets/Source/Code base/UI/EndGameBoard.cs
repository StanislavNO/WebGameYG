using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Source.Code_base.UI
{
    public class EndGameBoard : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _startMenu;

        private IReadOnlyTimer _timer;
        private SceneLoadMediator _sceneManager;

        [Inject]
        private void Construct(IReadOnlyTimer timer, SceneLoadMediator sceneLoadMediator)
        {
            _timer = timer;
            _sceneManager = sceneLoadMediator;
        }

        private void Awake()
        {
            _canvas.gameObject.SetActive(false);
            _timer.TimeCanceled += Show;
            _startMenu.onClick.AddListener(OnClickStartMenu);
        }

        private void OnDestroy()
        {
            _timer.TimeCanceled -= Show;
            _startMenu.onClick.RemoveListener(OnClickStartMenu);
        }

        private void OnClickStartMenu() =>
            _sceneManager.GoToMenu();

        private void Show() =>
            _canvas.gameObject.SetActive(true);
    }
}