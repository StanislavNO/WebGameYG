using Assets.Source.Code_base.UI;

namespace Assets.Source.Code_base
{
    public class SceneLoadMediator
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelLoader _levelLoader;
        private readonly LoadingCurtain _curtain;

        public SceneLoadMediator(ISceneLoader sceneLoader, ILevelLoader levelLoader, LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _levelLoader = levelLoader;
            _curtain = loadingCurtain;
        }

        public void GoToGameScene(LevelLoadingData data)
        {
            _curtain.Show();
            _levelLoader.Load(data);
        }

        public void GoToMenu()
        {
            _curtain.Show();
            _sceneLoader.Load(SceneID.Menu);
        }
    }
}