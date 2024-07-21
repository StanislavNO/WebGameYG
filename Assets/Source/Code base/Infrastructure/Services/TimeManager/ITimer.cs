namespace Assets.Source.Code_base
{
    public interface ITimer : IReadOnlyTimer
    {
        public void Start();
        public void Stop();
        public void Update(float deltaTime);
    }
}