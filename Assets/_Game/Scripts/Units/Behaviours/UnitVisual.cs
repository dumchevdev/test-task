﻿using UnityEngine;

namespace Game
{
    internal class UnitVisual : MonoBehaviour
    {
        [Header("VISUAL")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TrailRenderer _trailRenderer;
        
        private readonly Color _transparentColor = new(1, 1, 1, 0);

        internal void SetColor(Color color)
        {
            _spriteRenderer.color = color;
            _trailRenderer.startColor = color;
            _trailRenderer.endColor = _transparentColor;
        }
    }
}