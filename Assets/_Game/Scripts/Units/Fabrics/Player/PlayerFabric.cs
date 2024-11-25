using Game.Units.InputHandlers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    internal sealed class PlayerFabric
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;
        private readonly ReplaySystem _replaySystem;
        private readonly Vector2 _spawnPoint;
        private readonly UnitBehaviour _prefab;
        private readonly CloneFabric _cloneFabric;
        
        private PlayerContainer _playerContainer;

        internal PlayerFabric(PlayerData playerData, InputSystem inputSystem, Vector2 spawnPoint, ReplaySystem replaySystem, CloneFabric cloneFabric)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            _spawnPoint = spawnPoint;
            _replaySystem = replaySystem;
            _cloneFabric = cloneFabric;

            _prefab = Resources.Load<UnitBehaviour>(Constance.Units.UnitPrefabPath);
        }

        internal void Instantiate()
        {
            var behaviour = Object.Instantiate(_prefab, _spawnPoint, Quaternion.identity);

            ConfigureBehaviour(behaviour);
            ConfigurePlayer(behaviour);
        }
        
        private void ConfigureBehaviour(UnitBehaviour behaviour)
        {
            behaviour.name = Constance.Names.Player;
            behaviour.SetColor(_playerData.Color);

            var circleCollider = behaviour.GetComponent<CircleCollider2D>();
            var groundChecker = new GroundCheckerComponent(_playerData, behaviour.transform, circleCollider.radius);
            
            var replayRecorderComponent = new ReplayRecorderComponent(_playerData, _replaySystem);
            var gravityProcessor = new GravityProcessorComponent(_playerData);
            
            var rigidBody = behaviour.GetComponent<Rigidbody2D>();
            var velocityProcessor = new VelocityProcessorComponent(_playerData, rigidBody);
            
            behaviour.Construct(
                groundChecker, 
                replayRecorderComponent, 
                gravityProcessor, 
                velocityProcessor);
        }
        
        private void ConfigurePlayer(UnitBehaviour behaviour)
        {
            var movementHandler = new MovementInputHandler(_playerData, _inputSystem);
            var jumpHandler = new JumpInputHandler(_playerData, _inputSystem);
            var colorUpdatedHandler = new ColorUpdatedInputHandler(_playerData, _inputSystem, behaviour);
            var speedBoostHandler = new SpeedBoostInputHandler(_playerData, _inputSystem, behaviour);
            var cloneCreateHandler = new CloneCreatedInputHandler(_inputSystem, behaviour, _cloneFabric, _spawnPoint);

            var inputHandlersContainer = new InputHandlersContainer(
                movementHandler, 
                jumpHandler, 
                colorUpdatedHandler, 
                speedBoostHandler, 
                cloneCreateHandler);
            
            _playerContainer = new PlayerContainer(behaviour, _spawnPoint, inputHandlersContainer);
        }

        public void Dispose()
        {
            _playerContainer.Dispose();
        }
    }
}