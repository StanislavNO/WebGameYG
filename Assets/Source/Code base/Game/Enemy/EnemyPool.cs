using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyPool
    {
        private readonly EnemyFactory _factory;
        private readonly Queue<IEnemy> _enemies;

        public EnemyPool(EnemyFactory factory)
        {
            _factory = factory;
            _enemies = new();
        }

        public IEnemy GetEnemy()
        {
            IEnemy enemy;

            if (_enemies.Count == 0)
            {
                enemy = _factory.Create();
                enemy.Deactivated += OnPutEnemy;
                Debug.Log("Pool enemy.Create");
            }
            else
                enemy = _enemies.Dequeue();

            return enemy;
        }

        private void OnPutEnemy(IEnemy enemy) => _enemies.Enqueue(enemy);
    }
}