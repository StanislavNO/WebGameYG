using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _workPoint;
        [SerializeField] private float _speed;

        private Vector3 _startPosition;

        private void Awake() => _startPosition = _camera.position;

        private void Start() => StartCoroutine(GoToWorkPosition());

        private IEnumerator GoToWorkPosition()
        {
            while (_camera.position != _workPoint.position)
            {
                _camera.position = Vector3.MoveTowards(_camera.position, _workPoint.position, _speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}