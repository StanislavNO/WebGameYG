﻿using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Source.Code_base
{
    public class EnemySpawner 
    {
        private ICoroutineRunner _coroutineRunner;
        private EnemyPool _pool;

        private WaitForSeconds _coolDown;
        private float _spawnRadius;
        private Vector2 _center;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize(EnemyPool pool, EnemyConfig config)
        {
            _pool = pool;

            _coolDown = new(config.SpawnConfig.CoolDown);
            _spawnRadius = config.SpawnConfig.Radius;
            _center = config.SpawnConfig.Center2D;
        }

        public void Start()
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