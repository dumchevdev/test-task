using UnityEngine;

namespace Game
{
    internal class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        
        private InputSystem _inputSystem;
        private PlayerFabric _playerFabric;
        
        private void Awake()
        {
            InitializeSystems();
            InitializeFabrics();
        }

        private void InitializeSystems()
        {
            _inputSystem = new InputSystem();
        }
        
        private void InitializeFabrics()
        {
            _playerFabric = new PlayerFabric(spawnPoint.position);
        }

        private void Start()
        {
            _playerFabric.Spawn();
        }

        private void Update()
        {
            _inputSystem.OnUpdate();
        }
    }
}

