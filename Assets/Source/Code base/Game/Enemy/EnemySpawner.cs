using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Source.Code_base
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPool _pool;

        private WaitForSeconds _coolDown;
        private float _spawnRadius;
        private Vector2 _center;

        PlayerInput _input;

        public void Initialize(EnemyPool pool, EnemyConfig config, PlayerInput input)
        {
            _pool = pool;

            _coolDown = new(config.SpawnConfig.CoolDown);
            _spawnRadius = config.SpawnConfig.Radius;
            _center = config.SpawnConfig.Center2D;

            _input = input;
            _input.Player.Attack.started += test; 
        }

        private void test(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            StartCoroutine(Spawn());
        }

        private void Start()
        {
            //StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            IEnemy enemy;

            //while (enabled)
            //{
            yield return _coolDown;

            enemy = _pool.GetEnemy();
            enemy.SetPosition(GetRandomPosition());
            enemy.gameObject.SetActive(true);
            //}
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