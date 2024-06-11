using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyData
    {
        public EnemyData(Vector3 target)
        {
            TargetPosition = target;
            IsMovingToWork = true;
        }

        public bool IsMovingToWork { get; set; }
        public Vector3 StartPosition { get; set; }
        public Vector3 TargetPosition { get; private set; }
    }
}