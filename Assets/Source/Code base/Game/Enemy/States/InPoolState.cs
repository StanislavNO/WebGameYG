using System.Collections;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public class InPoolState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter InPool");
        }

        public void Exit()
        {
            Debug.Log("Exit InPool");
        }

        public void Update()
        {
        }
    }
}