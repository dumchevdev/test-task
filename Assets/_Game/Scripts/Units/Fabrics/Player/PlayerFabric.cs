using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    internal sealed class PlayerFabric
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;
        private readonly Vector2 _spawnPoint;
        private readonly UnitBehaviour _prefab;
        
        private PlayerContainer _playerContainer;

        internal PlayerFabric(PlayerData playerData, InputSystem inputSystem, Vector2 spawnPoint)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            _spawnPoint = spawnPoint;

            _prefab = Resources.Load<UnitBehaviour>(Constance.Units.UnitPrefabPath);
        }

        internal void Instantiate()
        {
            var behaviour = Object.Instantiate(_prefab, _spawnPoint, Quaternion.identity);
            var visual = behaviour.GetComponent<UnitVisual>();

            ConfigureBehaviour(behaviour, visual);
            ConfigurePlayer(behaviour, visual);
        }
        
        private void ConfigureBehaviour(UnitBehaviour behaviour, UnitVisual visual)
        {
            behaviour.name = Constance.Names.Player;
            visual.SetColor(_playerData.Color);

            var circleCollider = behaviour.GetComponent<CircleCollider2D>();
            var groundChecker = new GroundCheckerComponent(_playerData, behaviour.transform, circleCollider.radius);
            
            var gravityProcessor = new GravityProcessorComponent(_playerData);
            
            var rigidBody = behaviour.GetComponent<Rigidbody2D>();
            var velocityProcessor = new VelocityProcessorComponent(_playerData, rigidBody);
            
            behaviour.Construct(groundChecker, gravityProcessor, velocityProcessor);
        }
        
        private void ConfigurePlayer(UnitBehaviour behaviour, UnitVisual visual)
        {
            var movementHandler = new MovementInputHandler(_playerData, _inputSystem);
            var jumpHandler = new JumpInputHandler(_playerData, _inputSystem);
            var colorUpdatedHandler = new ColorUpdatedInputHandler(_playerData, _inputSystem, visual);
            var speedBoostHandler = new SpeedBoostInputHandler(_playerData, _inputSystem, behaviour, visual);
            
            var inputHandlersContainer = new InputHandlersContainer(movementHandler, jumpHandler, colorUpdatedHandler, speedBoostHandler);
            _playerContainer = new PlayerContainer(behaviour, visual, _spawnPoint, inputHandlersContainer);
        }

        public void Dispose()
        {
            _playerContainer.Dispose();
        }
    }
}