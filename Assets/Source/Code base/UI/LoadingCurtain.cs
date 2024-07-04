using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private float _fadeTime = 0.03f;

        private WaitForSeconds _delay;

        private void Awake() => _delay = new(_fadeTime);

        public void Show()
        {
            float fullAlpha = 1f;

            gameObject.SetActive(true);
            _curtain.alpha = fullAlpha;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= _fadeTime;
                yield return _delay;
            }

            gameObject.SetActive(false);
        }
    }
}