using UnityEngine;

namespace Assets.Source.Code_base
{
    [CreateAssetMenu(fileName = "EnemyConfigs", menuName = "Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public MoveStateConfig MoveStateConfig { get; private set; }
        [field: SerializeField] public float OffsetToTarget { get; private set; }
        [field: SerializeField] public float WorkCoolDown { get; private set; }
    }
}