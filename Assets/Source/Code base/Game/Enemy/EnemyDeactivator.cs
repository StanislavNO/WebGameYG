using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyDeactivator
    {
        public event Action<IEnemy> EnemyDeactivated;

        public void Deactivate(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            EnemyDeactivated?.Invoke(enemy);
        }
    }
}