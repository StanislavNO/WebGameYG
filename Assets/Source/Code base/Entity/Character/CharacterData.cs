using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class CharacterData
    {
        private Vector3 _gravity = Physics.gravity;
        private float _speed;

        public Vector3 Direction { get; private set; }

        public float Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _speed = value;
            }
        }

        public void SetDirection(Vector2 inputDelta)
        {
            Vector3 direction = ConvertInputToDirectionInWorld(inputDelta);
            Direction = direction;
        }

        private Vector3 ConvertInputToDirectionInWorld(Vector2 inputDelta)
        {
            Vector3 direction = new(inputDelta.x, 0, inputDelta.y);
            direction.Normalize();
            direction += _gravity;

            return direction;
        }
    }
}