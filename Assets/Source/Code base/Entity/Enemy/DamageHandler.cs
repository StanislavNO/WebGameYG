using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Collider))]
    public class DamageHandler : MonoBehaviour
    {
        public event Action DamageDetected;

        public bool IsWork { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<AttackPoint>(out _) && IsWork)
                DamageDetected?.Invoke();
        }
    }
}