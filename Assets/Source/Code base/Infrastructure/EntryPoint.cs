using Assets.Source.Code_base.UI;
using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private PlayerInput _input;
        private LoadingCurtain _curtain;

        [Inject]
        private void Construct(PlayerInput input, LoadingCurtain curtain)
        {
            _input = input;
            _curtain = curtain;
        }

        private void Awake()
        {
            _input.Enable();
            _curtain.Hide();
        }

        private void OnDestroy() => _input.Disable();
    }
}