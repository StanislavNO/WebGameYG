using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public interface IEnemy
    {
        event Action<Enemy> Deactivated;
        GameObject gameObject { get; }
        void SetPosition(Vector3 position);
    }
}