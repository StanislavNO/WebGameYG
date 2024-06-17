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
        private EnemyDeactivator _deactivator;

        private void Awake()
        {
            _input = new();
            _input.Enable();
            _player.Initialize(_input);

            _deactivator = new();
            _enemyFactory = new(_enemyConfig, _enemy, _deactivator);
            _enemyPool = new(_enemyFactory, _deactivator);
            _enemySpawner.Initialize(_enemyPool, _enemyConfig, _input);
        }

        private void OnDestroy()
        {
            _input.Disable();
        }
    }
}