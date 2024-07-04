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
            ReadCoins(_wallet.Coin);
            _wallet.CoinChanged += ReadCoins;
        }

        private void OnDisable() =>
            _wallet.CoinChanged -= ReadCoins;

        private void ReadCoins(int value) =>
            _text.text = value.ToString();
    }
}
