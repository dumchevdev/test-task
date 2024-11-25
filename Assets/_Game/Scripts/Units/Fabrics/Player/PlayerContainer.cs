using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    internal sealed class PlayerContainer : IDisposable
    {
        private readonly UnitBehaviour _behaviour;
        private readonly UnitVisual _visual;
        private readonly Vector2 _spawnPoint;
        private readonly InputHandlersContainer _inputHandlersContainer;

        public PlayerContainer(UnitBehaviour behaviour, UnitVisual visual, Vector2 spawnPoint, InputHandlersContainer inputHandlersContainer)
        {
            _behaviour = behaviour;
            _spawnPoint = spawnPoint;
            _inputHandlersContainer = inputHandlersContainer;
            _visual = visual;

            _behaviour.OnDied += OnRespawn;
        }

        private void OnRespawn()
        {
            _visual.SetEmittingTrail(false);
            _behaviour.SetPosition(_spawnPoint);
            _visual.SetEmittingTrail(true);
        }

        public void Dispose()
        {
            _inputHandlersContainer.Dispose();
            _behaviour.OnDied -= OnRespawn;
        }
    }
}