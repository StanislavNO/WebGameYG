using System;

namespace Assets.Source.Code_base
{
    public interface IDisable
    {
        event Action<Enemy> Deactivated;
        void Disable();
    }
}