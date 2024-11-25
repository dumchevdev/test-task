using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    internal class PlayerFabric
    {
        private readonly Vector2 _spawnPoint;
        private readonly UnitBehaviours _prefab;

        public PlayerFabric(Vector2 spawnPoint)
        {
            _spawnPoint = spawnPoint;
            
            _prefab = Resources.Load<UnitBehaviours>(Constance.Units.UnitPrefabPath);
        }

        internal void Spawn()
        {
            var behaviour = Object.Instantiate(_prefab, _spawnPoint, Quaternion.identity);
            var visual = behaviour.GetComponent<UnitVisual>();
            visual.SetColor(Color.black);
        }
    }
}