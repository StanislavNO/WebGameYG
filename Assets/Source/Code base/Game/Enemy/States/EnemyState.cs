using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Source.Code_base
{
    public abstract class EnemyState : IState
    {
        public EnemyState(IStateSwitcher switcher, EnemyView view)
        {
            Switcher = switcher;
            View = view;
        }

        protected IStateSwitcher Switcher { get; private set; }
        protected EnemyView View { get; private set; }

        public virtual void Enter()
        {
            Debug.Log(this);   
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }
    }
}