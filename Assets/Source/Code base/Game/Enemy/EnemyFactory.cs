using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyFactory
    {
        private readonly Enemy _prefab;
        private readonly Vector3 _enemyTarget;

        public EnemyFactory(EnemyConfig config, Enemy prefab)
        {
            _prefab = prefab;
            _enemyTarget = config.SpawnConfig.Center3D;
        }

        public Enemy Create()
        {
            Enemy enemy = Object.Instantiate(_prefab);
            enemy.Initialize(_enemyTarget);
            return _prefab;
        }
    }
}