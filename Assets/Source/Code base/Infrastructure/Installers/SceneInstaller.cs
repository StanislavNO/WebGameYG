using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Bootstrap _bootstrap;

        public override void InstallBindings()
        {
            Bootstrap bootstrap = Container.InstantiatePrefabForComponent<Bootstrap>(_bootstrap);

            Container.BindInterfacesAndSelfTo<Bootstrap>().FromInstance(bootstrap).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
        }
    }
}