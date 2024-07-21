using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base.UI
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private IReadOnlyWallet _wallet;

        [Inject]
        private void Construct(IReadOnlyWallet wallet)
        {
            _wallet = wallet;
        }

        private void OnEnable()
        {
            WriteCoins(_wallet.Coin);
            _wallet.CoinChanged += WriteCoins;
        }

        private void OnDisable() =>
            _wallet.CoinChanged -= WriteCoins;

        private void WriteCoins(int value) =>
            _text.text = value.ToString();
    }
}
