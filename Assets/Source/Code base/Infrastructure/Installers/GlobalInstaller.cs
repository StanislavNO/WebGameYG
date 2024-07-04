using Assets.Source.Code_base.UI;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _prefabHUD;

        public override void InstallBindings()
        {
            BindInputService();
            BindSceneLoader();
            BindLoadingCurtain();
            BindResources();
        }

        private void BindResources()
        {
            Container.BindInterfacesAndSelfTo<Wallet>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.Bind<SceneLoadMediator>().AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle().NonLazy();
        }

        private void BindLoadingCurtain()
        {
            LoadingCurtain loadingCurtain =
                Container.InstantiatePrefabForComponent<LoadingCurtain>(_prefabHUD);

            Container.Bind<LoadingCurtain>()
                .FromInstance(loadingCurtain)
                .AsSingle();
        }
    }
}