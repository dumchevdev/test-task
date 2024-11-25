using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Create UnitStats", fileName = "UnitStats")]
    internal sealed class UnitStats : ScriptableObject
    {
        [Header("MOVEMENT")]
        [SerializeField] internal float MaxSpeed = 30;
        [SerializeField] internal float Acceleration = 120;
        [SerializeField] internal float GroundingForce = -1.5f;
        
        [Header("JUMP")]
        [SerializeField] internal float JumpPower = 36;
        [SerializeField] internal float MaxFallSpeed = 40;
        [SerializeField] internal float FallAcceleration = 110;

        [Header("PHYSICS")] 
        [SerializeField] internal float GroundCheckerRadius = 0.2f;
    }
}