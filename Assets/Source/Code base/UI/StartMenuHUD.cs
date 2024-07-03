using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Source.Code_base.UI
{
    public class StartMenuHUD : MonoBehaviour
    {
        [SerializeField] private Button _startGame;

        private SceneLoadMediator _sceneManager;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator)
        {
            _sceneManager = sceneLoadMediator;
        }

        private void OnEnable() =>
            _startGame.onClick.AddListener(OnStartGameClick);

        private void OnDisable() =>
            _startGame.onClick.RemoveListener(OnStartGameClick);

        private void OnStartGameClick() =>
            _sceneManager.GoToGameScene(new LevelLoadingData());
    }
}