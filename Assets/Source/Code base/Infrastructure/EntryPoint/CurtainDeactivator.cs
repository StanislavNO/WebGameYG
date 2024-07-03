using Assets.Source.Code_base.UI;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class CurtainDeactivator : MonoBehaviour
    {
        private LoadingCurtain _loadingCurtain;

        [Inject]
        private void Construct(LoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }

        private void Start()
        {
            if (_loadingCurtain.enabled)
                _loadingCurtain.Hide();
        }
    }
}