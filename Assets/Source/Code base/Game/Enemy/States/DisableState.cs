using UnityEngine;

namespace Assets.Source.Code_base
{
    public class DisableState : IState
    {
        private readonly IDisable _enemy;
        private readonly IStateSwitcher _switcher;

        public DisableState(IDisable enemy, IStateSwitcher switcher)
        {
            _enemy = enemy;
            _switcher = switcher;
        }

        public void Enter()  
        {
            Debug.Log("Enter Disable");
            _switcher.SwitchState<InPoolState>();
        }

        public void Exit() 
        {
            Debug.Log("Exit Disable");
            _enemy.Disable(); 
        }

        public void Update() { }
    }
}