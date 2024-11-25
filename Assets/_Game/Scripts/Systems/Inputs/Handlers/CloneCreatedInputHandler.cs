using UnityEngine;

namespace Game.Units.InputHandlers
{
    internal sealed class CloneCreatedInputHandler : IInputHandler
    {
        private readonly InputSystem _inputSystem;
        private readonly UnitBehaviour _behaviour;
        private readonly CloneFabric _cloneFabric;
        private readonly Vector2 _spawnPoint;

        internal CloneCreatedInputHandler(InputSystem inputSystem, UnitBehaviour behaviour, CloneFabric cloneFabric, Vector2 spawnPoint)
        {
            _inputSystem = inputSystem;
            _behaviour = behaviour;
            _cloneFabric = cloneFabric;
            _spawnPoint = spawnPoint;

            _inputSystem.OnCloneCreated += OnCloneCreated;
        }

        private void OnCloneCreated()
        {
            _cloneFabric.SpawnClone();
            _behaviour.SetPosition(_spawnPoint);
        }

        public void Dispose()
        {
            _inputSystem.OnCloneCreated -= OnCloneCreated;
        }
    }
}