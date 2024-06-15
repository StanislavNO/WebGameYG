using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Character _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemySpawner _enemySpawner;

        [SerializeField] Transform _enemyTarget;

        private PlayerInput _input;
        private IInstantiator _container;

        private EnemyPool _enemyPool;
        private EnemyFactory _enemyFactory;

        private void Awake()
        {
            _input = new();
            _input.Enable();
            _player.Initialize(_input);

            _enemyFactory = new(_enemyConfig,_enemy);
            _enemyPool = new(_enemyFactory);
            _enemySpawner.Initialize(_enemyPool,_enemyConfig);
        }

        private void OnDestroy()
        {
            _input.Disable();
        }
    }
}