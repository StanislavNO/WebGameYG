using Zenject;

namespace Assets.Source.Code_base
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab;
        private readonly DiContainer _container;

        [Inject]
        public EnemyFactory(Enemy prefab, DiContainer container)
        {
            _prefab = prefab;
            _container = container;
        }

        public Enemy Get()
        {
            Enemy enemy = Create();
            _container.BindInterfacesAndSelfTo<Enemy>().FromInstance(enemy);

            return enemy;
        }

        private Enemy Create()
        {
            return _container.InstantiatePrefabForComponent<Enemy>(_prefab);
        }
    }
}