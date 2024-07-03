using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Source.Code_base.UI
{
    public class GameplayHUD : MonoBehaviour
    {
        [SerializeField] private Button _startMenuButton;

        private SceneLoadMediator _sceneManager;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator)
        {
            _sceneManager = sceneLoadMediator;
        }

        private void OnEnable() =>
            _startMenuButton.onClick.AddListener(OnStartMenuClick);

        private void OnDisable() =>
            _startMenuButton.onClick?.RemoveListener(OnStartMenuClick);

        private void OnStartMenuClick() => _sceneManager.GoToMenu();
    }
}