using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class SceneLoadMediator 
    {
        private ISceneLoader _sceneLoader;
        private ILevelLoader _levelLoader;

        public SceneLoadMediator(ISceneLoader sceneLoader, ILevelLoader levelLoader)
        {
            _sceneLoader = sceneLoader;
            _levelLoader = levelLoader;
        }

        public void GoToGameScene(LevelLoadingData data) =>
            _levelLoader.Load(data);

        public void GoToMenu() =>
            _sceneLoader.Load(SceneID.Menu);
    }
}