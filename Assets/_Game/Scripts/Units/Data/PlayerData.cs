using UnityEngine;

namespace Game
{
    internal sealed class PlayerData : UnitData
    {
        internal float CurrentSpeed;

        public PlayerData(UnitStats stats) : base(stats)
        {
            CurrentSpeed = stats.MaxSpeed;
            Color = Color.black;
        }
    }
}