using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private PlayerInput _input;

        [Inject]
        private void Construct(PlayerInput input)
        {
            _input = input;
        }

        private void Awake()
        {
            _input.Enable();
        }

        private void OnDestroy() => _input.Disable();
    }
}