using UnityEngine;

namespace Assets.Source.Code_base
{
    public interface IEnemy
    {
        GameObject gameObject {get;}
        void SetPosition(Vector3 position);
    }
}