using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Source.Code_base
{
    public class EnemySpawner : IInitializable
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EnemyPool _pool;

        private readonly WaitForSeconds _coolDown;
        private readonly float _spawnRadius;
        private readonly Vector2 _center;

        [Inject]
        public EnemySpawner(ICoroutineRunner coroutineRunner, EnemyPool pool, EnemyConfig config, EnemyTarget enemyTarget)
        {
            _coroutineRunner = coroutineRunner;
            _pool = pool;

            _coolDown = new(config.SpawnConfig.CoolDown);
            _spawnRadius = config.SpawnConfig.Radius;
            _center = new(enemyTarget.transform.position.x,
                          enemyTarget.transform.position.z);
        }

        public void Initialize()
        {
            _coroutineRunner.StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            IEnemy enemy;

            while (true)
            {
                yield return _coolDown;

                enemy = _pool.GetEnemy();
                enemy.SetPosition(GetRandomPosition());
                enemy.gameObject.SetActive(true);
            }
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 result = Vector3.up;
            float maxAngle = 360f;
            float alpha = Random.Range(0, maxAngle);

            result.x = _center.x + _spawnRadius * (float)Math.Cos(alpha);
            result.z = _center.y + _spawnRadius * (float)Math.Sin(alpha);

            return result;
        }
    }
}