using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Bootstrapper : MonoBehaviour
    {
        private SceneLoadMediator _sceneManager;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoadMediator)
        {
            _sceneManager = sceneLoadMediator;
        }

        private void Start() => _sceneManager.GoToMenu();
    }
}