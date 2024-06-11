using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public interface ICharacterState : IState
    {
        void HandleInput();
        void Update();
    }
}