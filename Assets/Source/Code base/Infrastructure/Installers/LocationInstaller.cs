﻿using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public sealed class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _characterSpawnPoint;
        [SerializeField] private Transform _enemyTargetSpawnPoint;

        [SerializeField] private Character _playerPrefab;
        [SerializeField] private EnemyTarget _enemyTargetPrefab;

        public override void InstallBindings()
        {
            BindEnemyTarget();
            BindCharacter();
        }

        private void BindCharacter()
        {
            Character character = Container.InstantiatePrefabForComponent<Character>
                (_playerPrefab, _characterSpawnPoint.position, Quaternion.identity, null);

            Container.Bind<ICharacter>()
                .FromInstance(character)
                .AsSingle();
        }

        private void BindEnemyTarget()
        {
            EnemyTarget enemyTarget = Container.InstantiatePrefabForComponent<EnemyTarget>
                (_enemyTargetPrefab, _enemyTargetSpawnPoint.position, Quaternion.identity, null);

            Container.Bind<EnemyTarget>()
                .FromInstance(enemyTarget)
                .AsSingle();
        }
    }
}