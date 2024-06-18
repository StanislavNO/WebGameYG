using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Character _player;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private EnemySpawner _enemySpawner;

        private PlayerInput _input;
        private IInstantiator _container;

        private EnemyPool _enemyPool;
        private EnemyFactory _enemyFactory;
        private EnemyDeactivator _deactivator;

        private void Awake()
        {
            CreateEntity();
            InitEntity();

            _input.Enable();
        }

        private void OnDestroy() => _input.Disable();

        private void CreateEntity()
        {
            _input = new();
            _deactivator = new();
            _enemyFactory = new(_enemyConfig, _prefab);
            _enemyPool = new(_enemyFactory);
        }

        private void InitEntity()
        {
            _player.Initialize(_input);
            _enemySpawner.Initialize(_enemyPool, _enemyConfig);
        }
    }
}