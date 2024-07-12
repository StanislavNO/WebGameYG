using System;

namespace Assets.Source.Code_base
{
    public class EnemyDeactivator
    {
        public event Action<IEnemy> EnemyDeactivated;
        public event Action EnemyDied;

        public void Deactivate(Enemy enemy, bool isDied = false)
        {
            enemy.gameObject.SetActive(false);
            EnemyDeactivated?.Invoke(enemy);

            if (isDied)
                EnemyDied?.Invoke();
        }
    }
}