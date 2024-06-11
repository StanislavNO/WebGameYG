using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public RunningStateConfig RunningStateConfig { get; private set; }
        [field: SerializeField] public AttackStateConfig AttackStateConfig { get; private set; }
    }

    [Serializable]
    public class RunningStateConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    }

    [Serializable]
    public class AttackStateConfig
    {
        [field: SerializeField] public float CoolDown { get; private set; }
    }
}