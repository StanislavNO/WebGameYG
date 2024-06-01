using System;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class CharacterData
    {
        public Vector3 DeltaInput;

        private float _speed;

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
    }
}