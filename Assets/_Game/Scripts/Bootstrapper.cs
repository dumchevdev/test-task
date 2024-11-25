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
            var _stats = Resources.Load<UnitStats>(Constance.Units.UnitStatsPath);
            var playerData = new PlayerData(_stats);

            _playerFabric = new PlayerFabric(playerData, _inputSystem, spawnPoint.position);
        }

        private void Start()
        {
            _playerFabric.Instantiate();
        }

        private void Update()
        {
            _inputSystem.OnUpdate();
        }
    }
}

