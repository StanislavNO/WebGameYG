using System;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Collider))]
    public class EnemyDeathHandler : MonoBehaviour
    {
        public event Action DamageDetected;

        private void OnTriggerEnter(Collider other)
        {
            if (TryGetComponent<AttackPoint>(out _))
                DamageDetected?.Invoke();
        }
    }
}