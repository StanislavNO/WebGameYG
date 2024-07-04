using System;

namespace Assets.Source.Code_base
{
    public class Wallet : IReadOnlyWallet
    {
        public Wallet(int coin = 0)
        {
            ValidatePositiveValue(coin);

            Coin = coin;
        }

        public event Action<int> CoinChanged;

        public int Coin { get; private set; }

        public bool IsEnough(int coin) => Coin - coin >= 0;

        public void AddCoin(int value)
        {
            ValidatePositiveValue(value);

            Coin += value;
            CoinChanged?.Invoke(Coin);
        }

        public void RemoveCoin(int value)
        {
            ValidatePositiveValue(value);

            Coin -= value;
            CoinChanged?.Invoke(Coin);
        }

        private void ValidatePositiveValue(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
