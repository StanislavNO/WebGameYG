using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class DisableState : EnemyState
    {
        public DisableState(IStateSwitcher switcher, EnemyView view) : base(switcher, view)
        {
        }
    }
}