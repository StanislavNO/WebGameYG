using Zenject;

namespace Assets.Source.Code_base
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab;
        private readonly DiContainer _container;
        private readonly PauseHandler _pauseHandler;

        [Inject]
        public EnemyFactory(Enemy prefab, DiContainer container, PauseHandler pauseHandler)
        {
            _prefab = prefab;
            _container = container;
            _pauseHandler = pauseHandler;
        }

        public Enemy Get()
        {
            Enemy enemy = Create();
            BindEnemy(enemy);
            _pauseHandler.Add(enemy);

            return enemy;
        }

        private Enemy Create() =>
            _container.InstantiatePrefabForComponent<Enemy>(_prefab);

        private void BindEnemy(Enemy enemy) =>
            _container.BindInterfacesAndSelfTo<Enemy>().FromInstance(enemy);
    }
}