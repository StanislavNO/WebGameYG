using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public MoveStateConfig MoveStateConfig { get; private set; }
        [field: SerializeField] public AttackStateConfig AttackStateConfig { get; private set; }
    }

    [Serializable]
    public class AttackStateConfig
    {
        [field: SerializeField] public float CoolDown { get; private set; }
    }
}