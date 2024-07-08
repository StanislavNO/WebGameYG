using System;

namespace Assets.Source.Code_base
{
    public interface IReadOnlyWallet
    {
        event Action<int> CoinChanged;
        int Coin { get; }
    }
}
