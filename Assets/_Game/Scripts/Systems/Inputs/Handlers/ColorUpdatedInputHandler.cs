namespace Game
{
    internal sealed class ColorUpdatedInputHandler : IInputHandler
    {
        private readonly PlayerData _playerData;
        private readonly InputSystem _inputSystem;
        private readonly UnitVisual _visual;

        internal ColorUpdatedInputHandler(PlayerData playerData, InputSystem inputSystem, UnitVisual visual)
        {
            _playerData = playerData;
            _inputSystem = inputSystem;
            _visual = visual;

            _inputSystem.OnColorUpdated += OnColorUpdated;
        }

        private void OnColorUpdated()
        {
            if (_playerData.BoostBlocked) return;
            
            var color = ColorExtension.GenerateColor();
            _playerData.Color = color;
            _visual.SetColor(color);
        }

        public void Dispose()
        {
            _inputSystem.OnColorUpdated -= OnColorUpdated;
        }
    }
}