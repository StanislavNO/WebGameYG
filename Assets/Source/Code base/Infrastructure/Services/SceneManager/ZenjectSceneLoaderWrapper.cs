using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Source.Code_base
{
    public class ZenjectSceneLoaderWrapper
    {
        private ZenjectSceneLoader _sceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Load(int sceneID, Action<DiContainer> action = null) =>
            _sceneLoader.LoadScene(sceneID, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}