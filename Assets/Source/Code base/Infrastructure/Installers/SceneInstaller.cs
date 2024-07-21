using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameLooper _gameLooper;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Enemy _enemyPrefab;

        public override void InstallBindings()
        {
            BindServices();
            BindEntryPoint();
            BindEnemy();
        }

        private void BindEntryPoint()
        {
            GameLooper gameLopper = Container.InstantiatePrefabForComponent<GameLooper>(_gameLooper);
            Container.Bind<ICoroutineRunner>().FromInstance(gameLopper).AsSingle();
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
            Container.BindInterfacesAndSelfTo<RewardHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<Timer>().AsSingle();
            Container.Bind<EnemyDeactivator>().AsSingle();
        }
    }
}