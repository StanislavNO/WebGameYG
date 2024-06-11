using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [Serializable]
    public class MoveStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    }
}