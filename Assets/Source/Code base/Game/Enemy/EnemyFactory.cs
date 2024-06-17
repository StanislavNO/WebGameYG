using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyFactory 
    {
        private readonly Enemy _prefab;
        private readonly Vector3 _enemyTarget;
        private readonly EnemyDeactivator _enemyDeactivator;

        public EnemyFactory(EnemyConfig config, Enemy prefab , EnemyDeactivator deactivator)
        {
            _prefab = prefab;
            _enemyTarget = config.SpawnConfig.Center3D;
            _enemyDeactivator = deactivator;
        }

        public Enemy Create()
        {
            Enemy enemy = Object.Instantiate(_prefab);
            enemy.Initialize(_enemyTarget, _enemyDeactivator);
            return _prefab;
        }
    }
}