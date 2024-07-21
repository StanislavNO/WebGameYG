using UnityEngine;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Collider))]
    public class AttackPoint : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        private void Awake()
        {
            _collider.isTrigger = true;
            gameObject.SetActive(false);
        }
    }
}