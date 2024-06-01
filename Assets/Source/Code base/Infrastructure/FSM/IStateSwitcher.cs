namespace Assets.Source.Code_base
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}