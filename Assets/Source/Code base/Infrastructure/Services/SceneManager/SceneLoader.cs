using System;

namespace Assets.Source.Code_base
{
    public class SceneLoader : ISceneLoader, ILevelLoader
    {
        private ZenjectSceneLoaderWrapper _loader;

        public SceneLoader(ZenjectSceneLoaderWrapper loader)
        {
            _loader = loader;
        }

        public void Load(LevelLoadingData data)
        {
            _loader.Load((int)SceneID.Game, 
                container => 
                { 
                    container.BindInstance(data); 
                });
        }

        public void Load(SceneID sceneID)
        {
            if (sceneID == SceneID.Game)
                throw new ArgumentException($"{SceneID.Game} cannot be started without configuration, use ILevelLoader");

            _loader.Load((int)sceneID);
        }
    }
}