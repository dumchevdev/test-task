using System;
using UnityEngine;

namespace Game
{
    internal sealed class InputSystem
    {
        internal event Action<float> HorizontalInputReceived;
        internal event Action JumpInitiated;
        
        internal void OnUpdate()
        {
            ProcessAxisInput(Constance.Inputs.HorizontalAxis, HorizontalInputReceived);
            ProcessButtonPress(Constance.Inputs.JumpAxis, JumpInitiated);
        }
        
        private void ProcessAxisInput(string axisName, Action<float> eventAction)
        {
            float axisValue = Input.GetAxis(axisName);
            if (Mathf.Abs(axisValue) > 0.01f)
            {
                eventAction?.Invoke(axisValue);
            }
        }

        private void ProcessButtonPress(string buttonName, Action eventAction)
        {
            if (Input.GetButtonDown(buttonName))
            {
                eventAction?.Invoke();
            }
        }
    }
}