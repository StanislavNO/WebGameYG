using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class EnemyTarget : MonoBehaviour
    {
        private const float WorkScaleSize = 0.15f;

        [SerializeField] private float _speed = 1f;

        private Transform _transform;
        private Vector3 _startScale;
        Coroutine _coroutine;

        private void Awake() => _transform = transform;

        private void Start()
        {
            _coroutine = StartCoroutine(ApplyWorkScale());
        }

        private void OnDestroy()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator ApplyWorkScale()
        {
            Vector3 newScale = Vector3.one * WorkScaleSize;
            float offset = 0.3f;

            while (Vector3.Distance( _transform.localScale , newScale) >= offset)
            {
                _transform.localScale = Vector3.Lerp(
                    _transform.localScale, newScale, Time.deltaTime * _speed);

                yield return null;
            }
        }
    }
}