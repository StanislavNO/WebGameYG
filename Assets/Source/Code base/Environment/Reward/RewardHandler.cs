using System;
using Zenject;

namespace Assets.Source.Code_base
{
    public class RewardHandler : IDisposable
    {
        private const int Reward = 10;

        private readonly IWallet _wallet;
        private readonly EnemyDeactivator _enemyDeactivator;

        [Inject]
        public RewardHandler(IWallet wallet, EnemyDeactivator enemyDeactivator)
        {
            _wallet = wallet;
            _enemyDeactivator = enemyDeactivator;

            _enemyDeactivator.EnemyDied += AddCoin;
        }


        public void Dispose() =>
            _enemyDeactivator.EnemyDied -= AddCoin;

        private void AddCoin() => _wallet.AddCoin(Reward);
    }
}