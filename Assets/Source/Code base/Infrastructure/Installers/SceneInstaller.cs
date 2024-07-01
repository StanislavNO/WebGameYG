using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private EntryPoint _bootstrap;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Enemy _enemyPrefab;

        public override void InstallBindings()
        {
            BindEntryPoint();
            BindServices();
            BindEnemy();
        }

        private void BindEntryPoint()
        {
            EntryPoint entryPont = Container.InstantiatePrefabForComponent<EntryPoint>(_bootstrap);
            Container.Bind<ICoroutineRunner>().FromInstance(entryPont).AsSingle();
        }

        private void BindEnemy()
        {
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<Enemy>().FromInstance(_enemyPrefab).AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
            Container.Bind<EnemyDeactivator>().AsSingle();
        }
    }
}