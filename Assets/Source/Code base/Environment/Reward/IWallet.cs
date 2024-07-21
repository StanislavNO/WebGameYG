namespace Assets.Source.Code_base
{
    public interface IWallet
    {
        void AddCoin(int value);
        bool TryRemoveCoin(int value);
    }
}
