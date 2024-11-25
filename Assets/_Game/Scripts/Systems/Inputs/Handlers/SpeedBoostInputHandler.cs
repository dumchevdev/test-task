using System.Collections;
using UnityEngine;

namespace Game
{
    internal sealed class SpeedBoostInputHandler : IInputHandler
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;
        private readonly UnitBehaviour _behaviour;
        private readonly UnitVisual _visual;

        internal SpeedBoostInputHandler(PlayerData playerData, InputSystem inputSystem, UnitBehaviour behaviour, UnitVisual visual)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            _behaviour = behaviour;
            _visual = visual;

            _inputSystem.OnSpeedBoost += OnSpeedBoost;
            _behaviour.OnDied += OnRespawn;
        }

        private void OnSpeedBoost()
        {
            if (_playerData.BoostBlocked) return;
            _behaviour.StartCoroutine(OnSpeedBoostInternal());
        }
        
        private IEnumerator OnSpeedBoostInternal()
        {
            _playerData.BoostBlocked = true;
            _playerData.CurrentSpeed *= _playerData.Stats.SpeedBoostMod;

            var firstColor = ColorExtension.GenerateColor();
            var secondColor = ColorExtension.GenerateColor();

            for (float timer = 0; timer <= _playerData.Stats.SpeedBoostDuration; timer += Time.deltaTime)
            {
                float intervalProgress = timer % _playerData.Stats.SpeedBoostAnimationInterval / _playerData.Stats.SpeedBoostAnimationInterval;
        
                if (Mathf.Approximately(intervalProgress, 0f))
                    (firstColor, secondColor) = (secondColor, firstColor);

                _visual.SetColor(Color.Lerp(firstColor, secondColor, intervalProgress));
                
                yield return null;
            }

            Reset();
        }
        
        private void OnRespawn()
        {
            Reset();
        }
        
        private void Reset()
        {
            _visual.SetColor(_playerData.Color);
            _behaviour.StopAllCoroutines();
            _playerData.BoostBlocked = false;
            _playerData.CurrentSpeed = _playerData.Stats.BaseSpeed;
        }

        public void Dispose()
        {
            _inputSystem.OnSpeedBoost -= OnSpeedBoost;
            _behaviour.OnDied -= OnRespawn;
        }
    }
}