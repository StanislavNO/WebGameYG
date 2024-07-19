using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Source.Code_base
{
    public class EnemySpawner : IInitializable, IPause
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EnemyPool _pool;

        private readonly float _coolDown;
        private readonly float _spawnRadius;
        private readonly Vector2 _center;

        private bool _isPaused;

        [Inject]
        public EnemySpawner(ICoroutineRunner coroutineRunner, EnemyPool pool, EnemyConfig config, EnemyTarget enemyTarget, PauseHandler pauseHandler)
        {
            _coroutineRunner = coroutineRunner;
            _pool = pool;

            _coolDown = config.SpawnConfig.CoolDown;
            _spawnRadius = config.SpawnConfig.Radius;
            _center = new(enemyTarget.transform.position.x,
                          enemyTarget.transform.position.z);

            _isPaused = false;
            pauseHandler.Add(this);
        }

        public void Initialize() =>
            _coroutineRunner.StartCoroutine(Spawn());

        public void SetPause(bool isPaused) => _isPaused = isPaused;

        private IEnumerator Spawn()
        {
            IEnemy enemy;
            float time = 0;

            while (true)
            {
                while (time < _coolDown)
                {
                    if (_isPaused == false)
                        time += Time.deltaTime;

                    yield return null;
                }

                enemy = _pool.GetEnemy();
                enemy.SetPosition(GetRandomPosition());
                enemy.gameObject.SetActive(true);

                time = 0;
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