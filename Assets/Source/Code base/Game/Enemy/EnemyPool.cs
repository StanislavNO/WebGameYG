using System.Collections.Generic;

namespace Assets.Source.Code_base
{
    public class EnemyPool
    {
        private readonly EnemyFactory _factory;
        private readonly Queue<IEnemy> _enemies;
        private readonly EnemyDeactivator _deactivator;

        public EnemyPool(EnemyFactory factory, EnemyDeactivator deactivator)
        {
            _factory = factory;
            _enemies = new Queue<IEnemy>();
            _deactivator = deactivator;

            _deactivator.EnemyDeactivated += PutEnemy;
        }

        public IEnemy GetEnemy()
        {
            Enemy enemy;

            if (_enemies.Count == 0)
            {
                UnityEngine.Debug.Log("Create");
                enemy = _factory.Create();

                return enemy;
            }

            return _enemies.Dequeue();
        }

        private void PutEnemy(IEnemy enemy) =>
            _enemies.Enqueue(enemy);
    }
}