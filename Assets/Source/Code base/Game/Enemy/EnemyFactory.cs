using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab;
        private readonly Vector3 _enemyTarget;
        private readonly EnemyDeactivator _deactivator;

        public EnemyFactory(EnemyConfig config, Enemy prefab, EnemyDeactivator deactivator)
        {
            _prefab = prefab;
            _enemyTarget = config.SpawnConfig.Center3D;
            _deactivator = deactivator;
        }

        public Enemy Create()
        {
            Enemy enemy = Object.Instantiate(_prefab);
            enemy.Initialize(_enemyTarget, _deactivator);
            return _prefab;
        }
    }
}