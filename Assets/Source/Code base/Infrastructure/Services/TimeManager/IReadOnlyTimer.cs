using System;

namespace Assets.Source.Code_base
{
    public interface IReadOnlyTimer
    {
        event Action<float> Tick;
        event Action TimeCanceled;
    }
}