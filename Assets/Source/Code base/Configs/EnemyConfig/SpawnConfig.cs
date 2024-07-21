using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [Serializable]
    public class SpawnConfig
    {
        [field: SerializeField] public float CoolDown { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public int Quantity { get; private set; }
    }
}