using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private EnemyConfig _enemyConfig;

        private PlayerInput _input;

        private EnemySpawner _enemySpawner;
        private EnemyPool _enemyPool;
        private EnemyFactory _enemyFactory;
        private EnemyDeactivator _deactivator;

        [Inject]
        private void Construct(PlayerInput input, EnemySpawner enemySpawner)
        {
            _input = input;
            _enemySpawner = enemySpawner;
        }

        private void Awake()
        {
            CreateEntity();
            InitEntity();

            _input.Enable();
        }

        private void OnDestroy() => _input.Disable();

        private void CreateEntity()
        {
            _deactivator = new();
            _enemyFactory = new(_enemyConfig, _prefab, _deactivator);
            _enemyPool = new(_enemyFactory, _deactivator);
        }

        private void InitEntity()
        {
            _enemySpawner.Initialize(_enemyPool, _enemyConfig);
            _enemySpawner.Start();
        }
    }
}