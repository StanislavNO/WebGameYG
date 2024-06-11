using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Character _player;
        [SerializeField] private Enemy _enemy;

        [SerializeField] Transform _enemyTarget;

        private PlayerInput _input;
        private IInstantiator _container;

        private void Awake()
        {
            _input = new();
            _input.Enable();
            _player.Initialize(_input);
            _enemy.Initialize(_enemyTarget.position);
        }

        private void OnDestroy()
        {
            _input.Disable();
        }
    }
}