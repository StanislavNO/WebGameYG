using System;
using System.Collections.Generic;
using Zenject;


namespace Assets.Source.Code_base
{
    public class EnemyPool : IDisposable
    {
        private readonly EnemyFactory _factory;
        private readonly Queue<IEnemy> _enemies;
        private readonly EnemyDeactivator _deactivator;

        [Inject]
        public EnemyPool(EnemyFactory factory, EnemyDeactivator deactivator)
        {
            _factory = factory;
            _enemies = new();
            _deactivator = deactivator;

            _deactivator.EnemyDeactivated += OnPutEnemy;
        }

        public void Dispose()
        {
            _deactivator.EnemyDeactivated -= OnPutEnemy;
        }

        public IEnemy GetEnemy()
        {
            IEnemy enemy;

            if (_enemies.Count == 0)
                enemy = _factory.Get();
            else
                enemy = _enemies.Dequeue();

            return enemy;
        }

        private void OnPutEnemy(IEnemy enemy) => _enemies.Enqueue(enemy);
    }
}