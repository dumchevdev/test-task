using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    internal class UnitBehaviours : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    }
}