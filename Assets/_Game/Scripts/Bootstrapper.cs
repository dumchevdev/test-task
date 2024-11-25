using UnityEngine;

namespace Game
{
    internal class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        
        private InputSystem _inputSystem;
        private ReplaySystem _replaySystem;
        private PlayerFabric _playerFabric;
        private CloneFabric _cloneFabric;
        
        private void Awake()
        {
            InitializeSystems();
            InitializeFabrics();
        }

        private void InitializeSystems()
        {
            _inputSystem = new InputSystem();
            _replaySystem = new ReplaySystem();
        }
        
        private void InitializeFabrics()
        {
            var _stats = Resources.Load<UnitStats>(Constance.Units.UnitStatsPath);
            var playerData = new PlayerData(_stats);
            
            _cloneFabric = new CloneFabric(_stats, playerData, _replaySystem, spawnPoint.position);
            _playerFabric = new PlayerFabric(playerData, _inputSystem, spawnPoint.position, _replaySystem, _cloneFabric);
        }

        private void Start()
        {
            _playerFabric.Instantiate();
        }

        private void Update()
        {
            _inputSystem.OnUpdate();
        }

        private void OnDestroy()
        {
            _playerFabric.Dispose();
            _cloneFabric.Dispose();
            _replaySystem.Dispose();
        }
    }
}

