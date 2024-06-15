using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [Serializable]
    public class SpawnConfig
    {
        [SerializeField] private Vector3 _spawnCenter;

        [field: SerializeField] public float CoolDown { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }

        public Vector2 Center2D => new(_spawnCenter.x, _spawnCenter.z);
        public Vector3 Center3D => _spawnCenter;

    }
}