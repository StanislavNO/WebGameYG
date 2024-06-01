using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}