using Assets.Source.Code_base.UI;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _prefabHUD;

        public override void InstallBindings()
        {
            BindSceneLoader();
            BindInputService();
            BindLoadingCurtain();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.Bind<SceneLoadMediator>().AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
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