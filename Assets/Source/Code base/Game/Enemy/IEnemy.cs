using UnityEngine;

namespace Assets.Source.Code_base
{
    public interface IEnemy
    {
        public GameObject gameObject {get;}
        void SetPosition(Vector3 position);
    }
}