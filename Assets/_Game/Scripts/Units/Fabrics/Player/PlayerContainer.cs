using System;

namespace Game
{
    internal sealed class PlayerContainer : IDisposable
    {
        private readonly InputHandlersContainer _inputHandlersContainer;

        public PlayerContainer(InputHandlersContainer inputHandlersContainer)
        {
            _inputHandlersContainer = inputHandlersContainer;
        }

        public void Dispose()
        {
            _inputHandlersContainer.Dispose();
        }
    }
}