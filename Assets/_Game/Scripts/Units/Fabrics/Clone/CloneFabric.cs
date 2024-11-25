﻿using System;
using UnityEngine;

namespace Game
{
    internal sealed class CloneFabric : IDisposable
    {
        private readonly PlayerData _playerData;
        private readonly ReplaySystem _replaySystem;
        private readonly Vector2 _spawnPoint;
        private readonly ClonePool _clonePool;
        
        internal CloneFabric(UnitStats stats, PlayerData playerData, ReplaySystem replaySystem, Vector2 spawnPoint)
        {
            _playerData = playerData;
            _replaySystem = replaySystem;
            _spawnPoint = spawnPoint;
            _clonePool = new ClonePool(stats);
        }

        internal void SpawnClone()
        {
            var clone = _clonePool.Get();
            clone.SetPosition(_spawnPoint);
            clone.SetActive(true);
            clone.SetColor(_playerData.Color);
            clone.Replay(_replaySystem);
        }
        
        public void Dispose()
        {
            _clonePool.Dispose();
        }
    }
}