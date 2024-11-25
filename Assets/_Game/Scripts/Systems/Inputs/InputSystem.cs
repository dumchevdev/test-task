using System;
using UnityEngine;

namespace Game
{
    internal sealed class InputSystem
    {
        public event Action<float> OnHorizontalInput;
        public event Action OnJumpPressed;
        
        internal void OnUpdate()
        {
            var horizontal = Input.GetAxis(Constance.Inputs.HorizontalAxis);
            if (horizontal != 0)
                OnHorizontalInput?.Invoke(horizontal);

            if (Input.GetButtonDown(Constance.Inputs.JumpAxis))
                OnJumpPressed?.Invoke();
        }
    }
}