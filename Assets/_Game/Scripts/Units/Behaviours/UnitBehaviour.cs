using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    internal sealed class UnitBehaviour : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private IFixedUpdateable[] _fixedUpdateables;
        
        internal event Action OnDied;

        internal void Construct(params IFixedUpdateable[] fixedUpdateables)
        {
            _fixedUpdateables = fixedUpdateables;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        internal void SetPosition(Vector2 position)
        {
            transform.position = position;
            _rigidbody.velocity = Vector2.zero;
        }
        
        private void FixedUpdate()
        {
            foreach (var component in _fixedUpdateables)
            {
                component.FixedUpdateInternal();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(Constance.Layers.DeathLayer))
                OnDied?.Invoke();
        }
    }
}