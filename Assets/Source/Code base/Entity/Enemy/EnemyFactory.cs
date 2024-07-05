using Zenject;

namespace Assets.Source.Code_base
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab;
        private readonly IInstantiator _container;
        private readonly PauseHandler _pauseHandler;

        [Inject]
        public EnemyFactory(Enemy prefab, IInstantiator container, PauseHandler pauseHandler)
        {
            _prefab = prefab;
            _container = container;
            _pauseHandler = pauseHandler;
        }

        public Enemy Get()
        {
            Enemy enemy = Create();
            _pauseHandler.Add(enemy);

            return enemy;
        }

        private Enemy Create() =>
            _container.InstantiatePrefabForComponent<Enemy>(_prefab);
    }
}