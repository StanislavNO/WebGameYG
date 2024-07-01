using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Collider))]
    public class DamageHandler : MonoBehaviour
    {
        public event Action DamageDetected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<AttackPoint>(out _))
                DamageDetected?.Invoke();
        }
    }
}