using UnityEngine;
using Zenject;

namespace Assets.Source.Code_base
{
    [RequireComponent(typeof(Collider))]
    public class RespawnZone : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private SpawnPoint _spawnPoint;

        private ICharacter _character;   

        [Inject]
        private void Construct(ICharacter character)
        {
            _character = character;
        }

        private void Awake() => _collider.isTrigger = true;

        private void OnTriggerEnter(Collider other)
        {
            _spawnPoint.ShowSpawn();
            _character.SetPosition(_spawnPoint.transform.position);
        }
    }
}