using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Code_base.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private Image _curtain;
        [SerializeField] private float _fadeTime = 0.03f;

        private WaitForSeconds _delay;

        private void Awake() => _delay = new(_fadeTime);

        public void Show()
        {
            float fullAmount = 1f;

            gameObject.SetActive(true);
            _curtain.fillAmount = fullAmount;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (_curtain.fillAmount > 0)
            {
                _curtain.fillAmount -= _fadeTime;
                yield return _delay;
            }

            gameObject.SetActive(false);
        }
    }
}