using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace Assets.Source.Code_base
{
    public class EnemyPool
    {
        private EnemyFactory _factory;
        private Queue<Enemy> _enemies;

        public EnemyPool(EnemyFactory factory)
        {
            _factory = factory;
            _enemies = new Queue<Enemy>();
        }

        public Enemy GetEnemy()
        {
            Enemy enemy;

            if (_enemies.Count == 0)
            {
                UnityEngine.Debug.Log("Create");
                enemy = _factory.Create();
                enemy.Deactivated.AddListener(PutEnemy);

                return enemy;
            }

            return _enemies.Dequeue();
        }

        private void PutEnemy(Enemy enemy)
        {
            _enemies.Enqueue(enemy);
            enemy.gameObject.SetActive(false);
        }
    }
}